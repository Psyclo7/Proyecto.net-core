using Microsoft.EntityFrameworkCore;
using Proyecto.net_core.Models;
using Proyecto.net_core.Models.Entidades;

namespace Proyecto.net_core.Services
{
    public class ServicioUsuario : IServicioUsuario
    {
        private readonly LibreriaContext _context;

        public ServicioUsuario(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUsuario(string correo, string password)
        {
            Usuario usuario = await _context.Usuarios.Where(u => u.correo == correo && u.password == password).FirstOrDefaultAsync();

            return usuario;
        }

        public async Task<Usuario> GetUsuario(string nombre_usuario)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.nombre_usuario == nombre_usuario);
        }

        public async Task<Usuario> GetUsuarioPorCorreo(string correo)
        {
            Usuario usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.correo == correo);

            return usuario;
        }

        public async Task<Usuario> SaveUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
