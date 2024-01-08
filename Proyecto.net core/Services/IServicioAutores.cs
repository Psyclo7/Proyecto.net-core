using Proyecto.net_core.Models.Entidades;

namespace Proyecto.net_core.Services
{
    public interface IServicioAutores
    {
        Task<Autor> GetAutor(String nombre_autor, String apellido_autor);
        Task<Autor> SaveAutor(Autor Autor);
        Task<Autor> GetAutor(String nombre_autor);
    }
}
