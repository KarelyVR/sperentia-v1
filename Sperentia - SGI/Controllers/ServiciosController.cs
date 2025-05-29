using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sperientia___SGI.Models.dbModels;
using Sperientia___SGI.Models.dbModels.DbContext;
using Sperientia___SGI.ViewModel;

namespace Sperientia___SGI.Controllers
{
    public class ServiciosController : Controller
    {
        private readonly SperientiaContext _context;

        public ServiciosController(SperientiaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Servicios.ToListAsync());
        }

        public IActionResult Create()
        {

            var servicio = new ServiciosViewModel
            {
                Divisa = _context.Divisas
                .Select(b => new SelectListItem
                {
                    Value = b.IdDivisa.ToString(),
                    Text = b.Nombre
                }).ToList(),
                Servicio = new Servicio()
            };

            return View(servicio);
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(ServiciosViewModel model)
        {
            try
            {
                //guardar datos servicio
                _context.Servicios.Add(model.Servicio);
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

            var servicio = await _context.Servicios
                .Include(x => x.Divisa)
                .FirstOrDefaultAsync(m => m.IdServicio == id);

            if (servicio == null)
            {
                return NotFound();
            }

            var viewModel = new ServiciosViewModel
            {
                Servicio = servicio
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Modificar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicios
                .Include(x => x.Divisa)
                .FirstOrDefaultAsync(m => m.IdServicio == id);

            if (servicio == null)
            {
                return NotFound();
            }

            var servicioVM = new ServiciosViewModel
            {
                Divisa = _context.Divisas.Select(t => new SelectListItem
                {
                    Value = t.IdDivisa.ToString(),
                    Text = t.Nombre
                }).ToList(),
                Servicio = servicio
            };

            return View(servicioVM);
        }

        [HttpPost]
        public async Task<IActionResult> ModificarRegistro(ServiciosViewModel model)
        {

            try
            {
                var servicioExiste = await _context.Servicios
                   .FirstOrDefaultAsync(x => x.IdServicio == model.Servicio.IdServicio);

                if (servicioExiste != null)
                {
                    //servicioExiste.IdServicio = model.Servicio.IdServicio;
                    servicioExiste.Nombre = model.Servicio.Nombre;
                    servicioExiste.Costo = model.Servicio.Costo;
                    servicioExiste.CostoDivisa = model.Servicio.CostoDivisa;
                    servicioExiste.CostoFrecuencia = model.Servicio.CostoFrecuencia;
                    servicioExiste.MetodoPago = model.Servicio.MetodoPago;
                    servicioExiste.FechaAdquisicion = model.Servicio.FechaAdquisicion;
                    servicioExiste.CuentaRegistrada = model.Servicio.CuentaRegistrada;
                    servicioExiste.Url = model.Servicio.Url;
                    servicioExiste.Notas = model.Servicio.Notas;

                    if (servicioExiste.Contrasena != model.Servicio.Contrasena)
                    {
                        servicioExiste.Contrasena = model.Servicio.Contrasena;
                        servicioExiste.UltimaModificacionContrasena = DateTime.Today;
                    }

                    _context.Update(servicioExiste);
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
