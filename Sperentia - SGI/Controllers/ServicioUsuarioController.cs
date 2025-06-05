using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sperientia___SGI.Filtros;
using Sperientia___SGI.Models.dbModels.DbContext;
using Sperientia___SGI.ViewModel;

namespace Sperientia___SGI.Controllers
{
    [ValidarAdmin]
    public class ServicioUsuarioController : Controller
    {
        private readonly SperientiaContext _context;

        public ServicioUsuarioController(SperientiaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var servicioV = await _context.ServicioUsuarios
                .Include(x => x.UsuarioLogin)
                .Include(x => x.Servicio)
                .ToListAsync();

            return View(servicioV);
        }

        public IActionResult Create()
        {

            var servicioVM = new ServiciosViewModel
            {
                Servicios = _context.Servicios
                .Select(b => new SelectListItem
                {
                    Value = b.IdServicio.ToString(),
                    Text = b.Nombre
                }).ToList(),
                Usuarios = _context.Users
                    .Select(t => new SelectListItem
                    {
                        Value = t.Id.ToString(),
                        Text = t.NombreCompleto
                    })
                .ToList()
            };

            return View(servicioVM);
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(ServiciosViewModel model)
        {
            try
            {

                //guardar datos inventario
                _context.ServicioUsuarios.Add(model.ServicioUsuario);
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

            }
            return RedirectToAction("Index");
        }
         
        public async Task<IActionResult> Detalles(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicio = await _context.ServicioUsuarios
                .Include(d => d.Servicio)
                .Include(d => d.UsuarioLogin)
                .FirstOrDefaultAsync(m => m.IdServicio == id);

            if (servicio == null)
            {
                return NotFound();
            }

            var viewModel = new ServiciosViewModel
            {
                ServicioUsuario = servicio
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Modificar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicio = await _context.ServicioUsuarios
                .Include(d => d.Servicio)
                .Include(d => d.UsuarioLogin)
                .FirstOrDefaultAsync(m => m.IdServicio == id);

            if (servicio == null)
            {
                return NotFound();
            }

            var servicioVM = new ServiciosViewModel
            {
                Servicios = _context.Servicios
                .Select(b => new SelectListItem
                {
                    Value = b.IdServicio.ToString(),
                    Text = b.Nombre
                }).ToList(),
                Usuarios = _context.Users
                    .Select(t => new SelectListItem
                    {
                        Value = t.Id.ToString(),
                        Text = t.NombreCompleto
                    })
                .ToList(),
                ServicioUsuario = servicio
            };

            return View(servicioVM);
        }

        [HttpPost]
        public async Task<IActionResult> ModificarRegistro(ServiciosViewModel model)
        {
            try
            {
                var servicioUsuarioExiste = await _context.ServicioUsuarios
                   .FirstOrDefaultAsync(x => x.IdServicio == model.ServicioUsuario.IdServicio);

                if (servicioUsuarioExiste != null)
                {

                    servicioUsuarioExiste.FechaAsignacion = model.ServicioUsuario.FechaAsignacion;
                    _context.Update(servicioUsuarioExiste);
                }

                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Registro actualizado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al actualizar el registro");
                return RedirectToAction("Index");
            }
        }
    }
}
