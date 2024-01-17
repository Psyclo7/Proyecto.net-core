using Microsoft.AspNetCore.Mvc;

namespace Proyecto.net_core.Services
{
    public class ServicioLibros : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
