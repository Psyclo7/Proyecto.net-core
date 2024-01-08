using Microsoft.EntityFrameworkCore;
using Proyecto.net_core.Models;
using Proyecto.net_core.Models.Entidades;

namespace Proyecto.net_core.Services
{
    public class ServicioCategoria : IServicioCategorias
    {
        private readonly LibreriaContext _context;

        public ServicioCategoria(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<Categoria> GetCategoria(string nombre_categoria, string descripcion)
        {
            Categoria Categoria = await _context.categorias.Where(u => u.nombre_categoria == nombre_categoria && u.descripcion == descripcion).FirstOrDefaultAsync();

            return Categoria;
        }

        public async Task<Categoria> GetCategoria(string nombre_categoria)
        {
            return await _context.categorias.FirstOrDefaultAsync(u => u.nombre_categoria == nombre_categoria);

        }

        public async Task<Categoria> SaveCategoria(Categoria Categoria)
        {
            _context.categorias.Add(Categoria);
            await _context.SaveChangesAsync();
            return Categoria;
        }
    }
}
