using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Sperientia___SGI.Models.dbModels.DbContext;
using Sperientia___SGI.Models.dbModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sperientia___SGI.ViewModel;

namespace MultasTransito.Controllers
{
    public class InventarioGeneralController : Controller
    {

        private readonly SperientiaContext _context;

        public InventarioGeneralController(SperientiaContext context)
        {
            _context = context;
        }

        // GET: Parametros
        public async Task<IActionResult> Index()
        {
            var model = await _context.InventarioGenerals
                .Include(x => x.Inventario)
                .ToListAsync();

            return View(model);

        }

        public IActionResult Create()
        {

            var inventarioVM = new InventarioViewModel
            {
                InventarioList = _context.Inventarios
                .Where(t => !_context.InventarioGenerals
                        .Select(u => u.IdInventario)
                        .Contains(t.IdInventario))
                .Select(b => new SelectListItem
                   {
                       Value = b.IdInventario.ToString(),
                       Text = b.Nombre
                   }).ToList(),
                General = new InventarioGeneral()
            };

            return View(inventarioVM);
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(InventarioViewModel model)
        {
            try
            {

                //guardar datos inventario
                _context.InventarioGenerals.Add(model.General);
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

            var general = await _context.InventarioGenerals
                .Include(d => d.Inventario)
                .FirstOrDefaultAsync(m => m.IdInventario == id);

            if (general== null)
            {
                return NotFound();
            }

            var viewModel = new InventarioViewModel
            {
                General = general
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Modificar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var general = await _context.InventarioGenerals
                .Include(d => d.Inventario)
                .FirstOrDefaultAsync(m => m.IdInventario == id);

            if (general == null)
            {
                return NotFound();
            }

            var viewModel = new InventarioViewModel
            {
                General = general
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ModificarRegistro(InventarioViewModel model)
        {
            try
            {
                var invExiste = await _context.InventarioGenerals
                   .FirstOrDefaultAsync(x => x.IdInventario == model.General.IdInventario);

                if (invExiste != null)
                {
                    invExiste.IdInventario = model.General.IdInventario;
                    invExiste.Marca = model.General.Marca;
                    invExiste.Modelo = model.General.Modelo;
                    invExiste.NumeroSerie = model.General.NumeroSerie;
                    invExiste.EstadoCondicion = model.General.EstadoCondicion;
                    invExiste.GarantiaFechaFin = model.General.GarantiaFechaFin;

                    _context.Update(invExiste);
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

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    var inventarioGeneral = await _context.InventarioGenerals.FindAsync(id);
        //    _context.InventarioGenerals.Remove(inventarioGeneral);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
    }
}