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
using Sperientia___SGI.Filtros;

namespace MultasTransito.Controllers
{
    //[ValidarAdmin]
    [NonAction]

    public class InventarioLibroController : Controller
    {

        private readonly SperientiaContext _context;

        public InventarioLibroController(SperientiaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context.InventarioLibroes
                .Include(x => x.Inventario)
                .ToListAsync();

            return View(model);

        }

        public IActionResult Create()
        {

            var inventarioVM = new InventarioViewModel
            {
                InventarioList = _context.Inventarios
                .Where(t => t.InventarioCategoria.Nombre == "Libro" &&
                    !_context.InventarioLibroes
                        .Select(il => il.IdInventario)
                        .Contains(t.IdInventario))
                .Select(b => new SelectListItem
                   {
                       Value = b.IdInventario.ToString(),
                       Text = b.Nombre
                   }).ToList(),
                Libro = new InventarioLibro()
            };

            return View(inventarioVM);
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(InventarioViewModel model)
        {
            try
            {
              
                //guardar datos inventario
                _context.InventarioLibroes.Add(model.Libro);
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

            var libro = await _context.InventarioLibroes
                .Include(d => d.Inventario)
                .FirstOrDefaultAsync(m => m.IdInventario == id);

            if (libro == null)
            {
                return NotFound();
            }

            var viewModel = new InventarioViewModel
            {
                Libro = libro
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Modificar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.InventarioLibroes
                .Include(d => d.Inventario)
                .FirstOrDefaultAsync(m => m.IdInventario == id);

            if (libro == null)
            {
                return NotFound();
            }

            var viewModel = new InventarioViewModel
            {
                Libro = libro
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ModificarRegistro(InventarioViewModel model)
        {
            try
            {
                var libroExiste = await _context.InventarioLibroes
                   .FirstOrDefaultAsync(x => x.IdInventario == model.Libro.IdInventario);

                if (libroExiste != null)
                {
                    libroExiste.IdInventario = model.Libro.IdInventario;
                    libroExiste.Autor = model.Libro.Autor;
                    libroExiste.Editorial = model.Libro.Editorial;
                    libroExiste.Isbn = model.Libro.Isbn;
                    libroExiste.Reseña = model.Libro.Reseña;
                    libroExiste.EsDigital = model.Libro.EsDigital;

                    _context.Update(libroExiste);
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
        //    var inventarioLibro = await _context.InventarioLibroes.FindAsync(id);
        //    _context.InventarioLibroes.Remove(inventarioLibro);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
    }
}