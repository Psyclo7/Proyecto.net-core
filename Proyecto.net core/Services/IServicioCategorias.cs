using Proyecto.net_core.Models.Entidades;

namespace Proyecto.net_core.Services
{
    public interface IServicioCategorias
    {
        Task<Categoria> GetCategoria(String nombre_categoria, String descripcion);
        Task<Categoria> SaveCategoria(Categoria Categoria);
        Task<Categoria> GetCategoria(String nombre_categoria);
    }
}
