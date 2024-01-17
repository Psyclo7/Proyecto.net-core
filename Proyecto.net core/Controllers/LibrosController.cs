using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.net_core.Models;
using Proyecto.net_core.Models.Entidades;
using Proyecto.net_core.Services;
using System.Linq.Expressions;

namespace Proyecto.net_core.Controllers
{
    public class LibrosController : Controller
    {
        private readonly IServicioUsuario _ServicioUsuario;
        private readonly IServicioImagen _ServicioImagen;
        private readonly IServicioLista servicioLista;
        private readonly LibreriaContext _context;

        public LibrosController(IServicioUsuario servicioUsuario, IServicioImagen servicioImagen, IServicioLista servicioLista, LibreriaContext context)
        {
            _ServicioUsuario = servicioUsuario;
            _ServicioImagen = servicioImagen;
            this.servicioLista = servicioLista;
            _context = context;
        }

        public async Task<IActionResult> ListadoLibros()
        {
            return View(await _context.Libros
                                 .Include(l => l.categoria)
                                 .Include(l => l.Autor)
                                 .ToListAsync());
        }

        public async Task<ActionResult> Crear()
        {
            Libro libro = new Libro()
            {
                Categorias = await servicioLista.GetListaCategoria(),
                Autores = await servicioLista.GetListaCategoria()
            };
            return View(libro);
        }
        [HttpPost]
        public async Task<ActionResult> Crear(Libro libro, IFormFile Imagen)
        {
            if (ModelState.IsValid)
            {
                Stream image = Imagen.OpenReadStream();
                string urlImagen = await _ServicioImagen.SubirImagen(image, Imagen.Name);

                libro.URLImagen = urlImagen;

                _context.Add(libro);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Libro creado exitosamente";
                return RedirectToAction("Lista");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "ha ocurrido un error");
            }
            libro.Categorias = await servicioLista.GetListaCategoria();
            libro.Autores = await servicioLista.GetListaAutores();
            return View(libro);
        }
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            libro.Categorias = await servicioLista.GetListaCategoria();
            libro.Autores = await servicioLista.GetListaAutores();
            return View(libro);
        }
        public async Task<ActionResult> Editar(Libro libro, IFormFile Imagen)
        {
            if (!ModelState.IsValid)
            {
                try
                {
                    var libroexistente = await _context.Libros.FindAsync(libro.id_libro);
                    if (libroexistente == null)
                    {
                        return NotFound();
                    }
                    if (Imagen == null)
                    {
                        Stream image = Imagen.OpenReadStream();
                        string urlImagen = await _ServicioImagen.SubirImagen(image, Imagen.Name);
                        libroexistente.URLImagen = urlImagen;
                    }
                    libroexistente.titulo = libro.titulo;
                    libroexistente.Autor = await _context.Autores.FindAsync(libro.id_autor);
                    libroexistente.categoria = await _context.categorias.FindAsync(libro.id_categoria);
                    libroexistente.precio = libro.precio;

                    _context.Update(libroexistente);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Libro cargado exitosamente";
                    return RedirectToAction("Lista");
                }
                catch (Exception ex)
                {
                    TempData["AlertMessage"] = ex;
                    return RedirectToAction("Lista");

                }

            }
            else
            {
                ModelState.AddModelError(string.Empty, "ha ocurrido un error");
            }
            libro.Categorias = await servicioLista.GetListaCategoria();
            libro.Autores = await servicioLista.GetListaAutores();
            return View(libro);
        }
    }
}