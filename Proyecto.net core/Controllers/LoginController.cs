using Microsoft.AspNetCore.Mvc;
using Proyecto.net_core.Models.Entidades;
using Proyecto.net_core.Models;
using Proyecto.net_core.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Proyecto.net_core.Controllers
{
    public class LoginController : Controller
    {
        private readonly IServicioUsuario _ServicioUsuario;
        private readonly IServicioImagen _ServicioImagen;
        private readonly LibreriaContext _context;

        public LoginController(IServicioUsuario ServicioUsuario,
            IServicioImagen ServicioImagen, LibreriaContext context)
        {
            _ServicioUsuario = ServicioUsuario;
            _ServicioImagen = ServicioImagen;
            _context = context;
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(Usuario usuario, IFormFile Imagen)
        {
            Stream image = Imagen.OpenReadStream();
            string urlImagen = await _ServicioImagen.SubirImagen(image, Imagen.FileName);

            usuario.password = Utilitarios.EncriptarClave(usuario.password);
            usuario.URLFotoPerfil = urlImagen;

            Usuario usuarioCreado = await _ServicioUsuario.SaveUsuario(usuario);

            if (usuarioCreado.id_usuario > 0)
            {
                return RedirectToAction("IniciarSesion", "Login");
            }

            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string correo, string clave)
        {
            Usuario usuarioEncontrado = await _ServicioUsuario.GetUsuario(correo, Utilitarios.EncriptarClave(clave));

            if (usuarioEncontrado == null)
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuarioEncontrado.nombre_usuario),
                new Claim("FotoPerfil", usuarioEncontrado.URLFotoPerfil),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );

            return RedirectToAction("Index", "Home");

        }
    }
}
