using Microsoft.AspNetCore.Mvc;
using Proyecto.net_core.Models.Entidades;
using Proyecto.net_core.Models;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.net_core.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly LibreriaContext _context;

        public CategoriasController(LibreriaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ListadoCategorias()
        {
            return View(await _context.categorias.ToListAsync());
        }
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoria);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Autor creado exitosamente";
                return RedirectToAction("ListadoAutores");
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Ha ocurrido un error");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.categorias == null)
            {
                return NotFound();
            }
            var categoria = await _context.categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(int id, Categoria categoria)
        {
            if (id != categoria.id_categoria)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoria);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Categoria actualizado" + "exitosamente";
                    return RedirectToAction("ListadoCategorias");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(ex.Message, "Ocurrio un error " + "al actualizar");
                }

            }
            return View(categoria);
        }
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.categorias == null)
            {
                return NotFound();
            }
            var categoria = await _context.categorias.FirstOrDefaultAsync(n => n.id_categoria == id);
            if (categoria == null)
            {
                return NotFound();
            }
            try
            {
                _context.categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Categoria eliminada" + "exitosamente";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error " + "no se pudo eliminar");
            }
            return RedirectToAction(nameof(ListadoCategorias));
        }



    }
}
