using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.net_core.Models.Entidades;
using Proyecto.net_core.Models;

namespace Proyecto.net_core.Controllers
{
    public class EditorialesController : Controller
    {
        private readonly LibreriaContext _context;

        public EditorialesController(LibreriaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ListadoEditoriales()
        {
            return View(await _context.Editoriales.ToListAsync());
        }
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Editorial editorial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(editorial);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Editor creado exitosamente";
                return RedirectToAction("ListadoEditoriales");
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Ha ocurrido un error");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.Editoriales == null)
            {
                return NotFound();
            }
            var editorial = await _context.Editoriales.FindAsync(id);
            if (editorial == null)
            {
                return NotFound();
            }
            return View(editorial);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(int id, Editorial editorial)
        {
            if (id != editorial.id_editorial)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editorial);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Editor actualizado" + "exitosamente";
                    return RedirectToAction("ListadoEditoriales");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(ex.Message, "Ocurrio un error " + "al actualizar");
                }

            }
            return View(editorial);
        }
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.Editoriales == null)
            {
                return NotFound();
            }
            var editorial = await _context.Editoriales.FirstOrDefaultAsync(n => n.id_editorial == id);
            if (editorial == null)
            {
                return NotFound();
            }
            try
            {
                _context.Editoriales.Remove(editorial);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Editor eliminado" + "exitosamente";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error " + "no se pudo eliminar");
            }
            return RedirectToAction(nameof(ListadoEditoriales));
        }



    }
}
