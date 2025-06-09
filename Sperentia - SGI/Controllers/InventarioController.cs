using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sperientia___SGI.Filtros;
using Sperientia___SGI.Models.dbModels;
using Sperientia___SGI.Models.dbModels.DbContext;
using Sperientia___SGI.ViewModel;
using System.Security.Claims;

namespace Sperientia___SGI.Controllers
{
    [ValidarAdmin]
    public class InventarioController : Controller
    {
        private readonly SperientiaContext _context;

        public InventarioController(SperientiaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context.Inventarios
                .Include(x => x.InventarioCategoria)
                .ToListAsync();

            return View(model);

        }

        public IActionResult Create()
        {

            var inventarioVM = new InventarioViewModel
            {
                InventarioCategoria = _context.InventarioCategorias
                   .Select(b => new SelectListItem
                   {
                       Value = b.IdCategoria.ToString(),
                       Text = b.Nombre
                   }).ToList(),
                Inventario = new Inventario(),
                Libro = new InventarioLibro(),
                General = new InventarioGeneral()
            };

            return View(inventarioVM);
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(InventarioViewModel model)
        {
            var rutaBase = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/inv");

            try
            {
                var inventarioId = model.Inventario.IdInventario;
                var baseD = Directory.GetCurrentDirectory();

                if (!Directory.Exists(rutaBase))
                    Directory.CreateDirectory(rutaBase);

                // Guardar foto
                if (model.Fotografia != null && model.Fotografia.Length > 0)
                {
                    var nombreArchivo = $"foto_{inventarioId}_{Path.GetFileName(model.Fotografia.FileName)}";
                    var rutaCompleta = Path.Combine(rutaBase, nombreArchivo);

                    using (var stream = new FileStream(rutaCompleta, FileMode.Create))
                    {
                        await model.Fotografia.CopyToAsync(stream);
                    }

                    model.Inventario.Foto = $"/img/inv/{nombreArchivo}";
                }

                //guardar datos inventario
                _context.Inventarios.Add(model.Inventario);
                await _context.SaveChangesAsync();

                if (model.Inventario.IdCategoria == 1)
                {
                    model.Libro.IdInventario = model.Inventario.IdInventario;
                    _context.InventarioLibroes.Add(model.Libro);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    model.General.IdInventario = model.Inventario.IdInventario;
                    _context.InventarioGenerals.Add(model.General);
                    await _context.SaveChangesAsync();
                }

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

            var inventario = await _context.Inventarios
                .Include(d => d.InventarioCategoria)
                .FirstOrDefaultAsync(m => m.IdInventario == id);

            if (inventario == null)
            {
                return NotFound();
            }

            var viewModel = new InventarioViewModel
            {
                Inventario = inventario
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Modificar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventarios
                .Include(d => d.InventarioCategoria)
                .FirstOrDefaultAsync(m => m.IdInventario == id);

            if (inventario == null)
            {
                return NotFound();
            }

            var viewModel = new InventarioViewModel
            {
                InventarioCategoria = _context.InventarioCategorias.Select(t => new SelectListItem
                {
                    Value = t.IdCategoria.ToString(),
                    Text = t.Nombre
                }).ToList(),
                Inventario = inventario
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ModificarRegistro(InventarioViewModel model)
        {
            var rutaBase = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/inv");

            try
            {
                if (model.Fotografia != null && model.Fotografia.Length > 0)
                {
                    var nombreCorto = Convert.ToBase64String(Guid.NewGuid().ToByteArray())
                        .Replace("=", "").Replace("+", "").Replace("/", "")
                        .Substring(0, 8);
                    var nuevoNombre = $"img_{nombreCorto}{Path.GetExtension(model.Fotografia.FileName)}";
                    var nuevaRuta = Path.Combine(rutaBase, nuevoNombre);

                    using (var stream = new FileStream(nuevaRuta, FileMode.Create))
                        await model.Fotografia.CopyToAsync(stream);

                    model.Inventario.Foto = $"/img/inv/{nuevoNombre}";
                }

                var inventarioExiste = await _context.Inventarios
                   .FirstOrDefaultAsync(x => x.IdInventario == model.Inventario.IdInventario);

                if (inventarioExiste != null)
                {
                    inventarioExiste.CodigoInterno = model.Inventario.CodigoInterno;
                    inventarioExiste.Nombre = model.Inventario.Nombre;
                    inventarioExiste.IdCategoria = model.Inventario.IdCategoria;
                    inventarioExiste.Descripcion = model.Inventario.Descripcion;
                    inventarioExiste.Proveedor = model.Inventario.Proveedor;
                    inventarioExiste.FechaCompra = model.Inventario.FechaCompra;
                    inventarioExiste.Costo = model.Inventario.Costo;
                    inventarioExiste.Foto =
                        !string.IsNullOrEmpty(model.Inventario.Foto)
                          ? model.Inventario.Foto
                          : inventarioExiste.Foto;

                    _context.Update(inventarioExiste);
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
