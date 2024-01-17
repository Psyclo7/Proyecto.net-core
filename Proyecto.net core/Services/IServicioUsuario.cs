using Proyecto.net_core.Models.Entidades;
using System.Threading.Tasks;

namespace Proyecto.net_core.Services
{
    public interface IServicioUsuario
    {
        Task<Usuario> GetUsuario(String correo, String password);
        Task<Usuario> SaveUsuario(Usuario usuario);
        Task<Usuario> GetUsuario(String nombre_usuario);
        Task<Usuario> GetUsuarioPorCorreo(String correo);
    }
}
