using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto.net_core.Models;

namespace Proyecto.net_core.Services
{
    public class ServicioLista : IServicioLista
    {
        private readonly LibreriaContext _context;

        public ServicioLista(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetListaAutores()
        {
            List<SelectListItem> list = await _context.Autores.Select(x => new SelectListItem{
                Text = x.nombre_autor,
                    Value = $"{x.id_autor}"
            })
                .OrderBy(x => x.Text)
                .ToListAsync();
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un autor...]",
                Value = "0"
            });
            return list;
        }

        public async Task<IEnumerable<SelectListItem>> GetListaCategoria()
        {
            List<SelectListItem> list = await _context.categorias.Select(x => new SelectListItem
            {
                Text = x.nombre_categoria,
                Value = $"{x.id_categoria}"
            })
                .OrderBy(x => x.Text)
                .ToListAsync();
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una cateogoria...]",
                Value = "0"
            });
            return list;
        }
    }
}
