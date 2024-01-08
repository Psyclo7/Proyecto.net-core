using Microsoft.EntityFrameworkCore;
using Proyecto.net_core.Models;
using Proyecto.net_core.Models.Entidades;

namespace Proyecto.net_core.Services
{
    public class ServicioAutores : IServicioAutores
    {
        private readonly LibreriaContext _context;

        public ServicioAutores(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<Autor> GetAutor(string nombre_autor, string apellido_autor)
        {
            Autor Autor = await _context.Autores.Where(u => u.nombre_autor == nombre_autor && u.apellido_autor == apellido_autor).FirstOrDefaultAsync();

            return Autor;
        }
        public async Task<Autor> GetAutor(string nombre_autor)
        {
            return await _context.Autores.FirstOrDefaultAsync(u => u.nombre_autor == nombre_autor);
        }

        public async Task<Autor> SaveAutor(Autor autor)
        {
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();
            return autor;
        }
    }
}
