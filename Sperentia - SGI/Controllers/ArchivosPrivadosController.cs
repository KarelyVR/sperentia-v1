using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sperientia___SGI.Models.dbModels;

namespace Sperientia___SGI.Controllers
{
    [Authorize]
    public class ArchivosPrivadosController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly string _rutaBase;
        private readonly string _imagenPorDefecto;

        public ArchivosPrivadosController(UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
            _rutaBase = Path.Combine(_webHostEnvironment.ContentRootPath, "ArchivosPrivados"); // Carpeta segura
            _imagenPorDefecto = Path.Combine(_webHostEnvironment.WebRootPath, "img", "PerfilDefault.jpg");
        }

        public async Task<IActionResult> ObtenerImagenPerfil(int id)
        {
            var usuarioActual = await _userManager.GetUserAsync(User);
            if (usuarioActual == null) return Unauthorized();

            var usuarioSolicitado = await _userManager.FindByIdAsync(id.ToString());
            if (usuarioSolicitado == null) return NotFound();

            // Verificar si el usuario es administrador
            var esAdmin = await _userManager.IsInRoleAsync(usuarioActual, "Administrador");

            // Solo permitir acceso si:
            // - Es administrador
            // - Está accediendo a su propia imagen
            if (!esAdmin && usuarioActual.Id != usuarioSolicitado.Id)
            {
                return Forbid(); // No autorizado
            }

            // Construir la ruta de la imagen del usuario
            string rutaImagen = string.IsNullOrEmpty(usuarioSolicitado.FotografiaUrl)
                ? _imagenPorDefecto
                : Path.Combine(_rutaBase, "Empleados", "FotosPerfil", usuarioSolicitado.FotografiaUrl);

            if (!System.IO.File.Exists(rutaImagen))
            {
                rutaImagen = _imagenPorDefecto;
            }

            // Servir la imagen como respuesta
            var fileStream = new FileStream(rutaImagen, FileMode.Open, FileAccess.Read);
            return File(fileStream, "image/jpeg"); // Cambiar MIME si hay diferentes formatos
        }
    }
}
