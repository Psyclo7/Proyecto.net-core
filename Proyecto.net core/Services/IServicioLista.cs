using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Proyecto.net_core.Services
{
    public interface IServicioLista
    {
        Task<IEnumerable<SelectListItem>>
            GetListaAutores();
        Task<IEnumerable<SelectListItem>>
            GetListaCategoria();
    }
}
