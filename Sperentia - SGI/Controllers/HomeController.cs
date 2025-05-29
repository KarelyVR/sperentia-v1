using Microsoft.AspNetCore.Mvc;
using Sperientia___SGI.Models;
using System.Diagnostics;

namespace Sperientia___SGI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Home/Error")]
        public IActionResult Error(int? statusCode = null)
        {
            var errorName = statusCode switch
            {
                400 => "Bad Request",
                403 => "Forbidden",
                404 => "Not Found",
                500 => "Internal Server Error",
                _ => "Error"
            };

            var errorMessage = statusCode switch
            {
                400 => "La solicitud no pudo ser procesada por uno o más datos incorrectos.",
                403 => "Acceso denegado. No tienes permisos para ver este recurso.",
                404 => "Lo página o recurso que buscas no existe.",
                500 => "Error interno del servidor. Intenta más tarde, si el problema persiste contacta a un administrador.",
                _ => "Ha ocurrido un error inesperado. Intenta más tarde, si el problema persiste contacta a un administrador"
            };

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Json(new { error = true, statusCode, message = errorMessage });
            }

            ViewData["StatusCode"] = statusCode ?? 500;
            ViewData["StatusName"] = errorName;
            ViewData["Message"] = errorMessage;

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
