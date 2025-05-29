using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sperientia___SGI.Models.dbModels;
using Sperientia___SGI.Models.dbModels.DbContext;
using Sperientia___SGI.ViewModel;

namespace Sperientia___SGI.Controllers
{
    public class AusenciasController : Controller
    {
        private readonly SperientiaContext _context;

        public AusenciasController(SperientiaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context.Ausencias
                .Include(x => x.UsuarioLogin)
                .ToListAsync();

            return View(model);
        }
        public IActionResult Create()
        {

            var ausenciaVM = new AusenciaViewModel
            {
                Usuario = _context.Users
                    .Select(t => new SelectListItem
                    {
                        Value = t.Id.ToString(),
                        Text = t.NombreCompleto
                    })
                .ToList(),
                Ausencia = new Ausencia()
            };

            return View(ausenciaVM);
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(AusenciaViewModel model)
        {
            try
            {
                //guardar datos ausencia
                _context.Ausencias.Add(model.Ausencia);
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

            var ausencia = await _context.Ausencias
                .Include(d => d.UsuarioLogin)
                .FirstOrDefaultAsync(m => m.IdAusencia == id);

            if (ausencia == null)
            {
                return NotFound();
            }

            var viewModel = new AusenciaViewModel
            {
                Ausencia = ausencia
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Modificar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ausencia = await _context.Ausencias
                .Include(d => d.UsuarioLogin)
                .FirstOrDefaultAsync(m => m.IdAusencia == id);

            if (ausencia == null)
            {
                return NotFound();
            }

            var ausenciaVM = new AusenciaViewModel
            {
                Usuario = _context.Users
                     .Select(t => new SelectListItem
                     {
                         Value = t.Id.ToString(),
                         Text = t.NombreCompleto
                     })
                 .ToList(),
                Ausencia = ausencia
            };

            return View(ausenciaVM);
        }

        [HttpPost]
        public async Task<IActionResult> ModificarRegistro(AusenciaViewModel model)
        {
           
            try
            {
                var ausenciaExiste = await _context.Ausencias
                   .FirstOrDefaultAsync(x => x.IdAusencia == model.Ausencia.IdAusencia);

                if (ausenciaExiste != null)
                {
                    ausenciaExiste.IdUsuario = model.Ausencia.IdUsuario;
                    ausenciaExiste.FechaInicio = model.Ausencia.FechaInicio;
                    ausenciaExiste.FechaFin = model.Ausencia.FechaFin;
                    ausenciaExiste.MotivoAusencia = model.Ausencia.MotivoAusencia;

                    _context.Update(ausenciaExiste);
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
