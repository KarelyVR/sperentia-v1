using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sperientia___SGI.Filtros;
using Sperientia___SGI.Models.dbModels.DbContext;
using Sperientia___SGI.ViewModel;

namespace Sperientia___SGI.Controllers
{
    [ValidarAdmin]
    public class InventarioAsignacionController : Controller
    {
        private readonly SperientiaContext _context;

        public InventarioAsignacionController(SperientiaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var inventarioA = await _context.InventarioAsignacions
                .Include(x => x.UsuarioLogin)
                .Include(x => x.Inventario)
                .ToListAsync();


            return View(inventarioA);

        }

        public IActionResult Create()
        {

            var inventarioVM = new InventarioViewModel
            {
                InventarioList = _context.Inventarios
                .Select(b => new SelectListItem
                {
                    Value = b.IdInventario.ToString(),
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

            return View(inventarioVM);
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(InventarioViewModel model)
        {
            try
            {

                //guardar datos inventario
                _context.InventarioAsignacions.Add(model.Asignar);
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

            var asignacion = await _context.InventarioAsignacions
                .Include(d => d.Inventario)
                .Include(d => d.UsuarioLogin)
                .FirstOrDefaultAsync(m => m.IdInventario == id);

            if (asignacion == null)
            {
                return NotFound();
            }

            var viewModel = new InventarioViewModel
            {
                Asignar = asignacion
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Modificar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.InventarioAsignacions
                .Include(d => d.Inventario)
                .Include(d => d.UsuarioLogin)
                .FirstOrDefaultAsync(m => m.IdInventario == id);

            if (asignacion == null)
            {
                return NotFound();
            }

            var inventarioVM = new InventarioViewModel
            {
                InventarioList = _context.Inventarios
                .Select(b => new SelectListItem
                {
                    Value = b.IdInventario.ToString(),
                    Text = b.Nombre
                }).ToList(),
                Usuarios = _context.Users
                    .Select(t => new SelectListItem
                    {
                        Value = t.Id.ToString(),
                        Text = t.NombreCompleto
                    })
                .ToList(),
                Asignar = asignacion
            };

            return View(inventarioVM);
        }

        [HttpPost]
        public async Task<IActionResult> ModificarRegistro(InventarioViewModel model)
        {
            try
            {
                var asignacionExiste = await _context.InventarioAsignacions
                   .FirstOrDefaultAsync(x => x.IdInventario == model.Asignar.IdInventario);

                if (asignacionExiste != null)
                {
                    //asignacionExiste.IdInventario = model.Asignar.IdInventario;
                    //asignacionExiste.IdUsuario = model.Asignar.IdUsuario;
                    asignacionExiste.FechaEntrega = model.Asignar.FechaEntrega;
                    asignacionExiste.FechaDevolucion = model.Asignar.FechaDevolucion;
                    asignacionExiste.Nota = model.Asignar.Nota;

                    _context.Update(asignacionExiste);
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
