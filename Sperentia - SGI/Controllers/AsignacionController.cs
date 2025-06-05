using Microsoft.AspNetCore.Mvc;
using Sperientia___SGI.Filtros;

namespace Sperientia___SGI.Controllers
{
    [ValidarAdmin]
    public class AsignacionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult Create()
        {
            return View();
        }  
        public IActionResult Modificar()
        {
            return View();
        }  
        public IActionResult Detalles()
        {
            return View();
        }
    }
}
