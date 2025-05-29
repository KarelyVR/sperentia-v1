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
using Sperientia___SGI.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace MultasTransito.Controllers
{
    public class BeneficioController : Controller
    {

        private readonly SperientiaContext _context;

        public BeneficioController(SperientiaContext context)
        {
            _context = context;
        }

        // GET: Parametros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Beneficios.ToListAsync());
        }


        public IActionResult Prueba()
        {
            if (int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int currentUserId))
            {
                ViewBag.CurrentUserId = currentUserId;
            }

            //// Obtener los beneficios que el usuario ya tiene asignados
            //var beneficiosUsuario = _context.BeneficioUsuarios
            //    .Where(bu => bu.IdUsuarioInformacion == currentUserId)
            //    .Select(bu => bu.Beneficio)
            //    .ToList();

            //// Obtener todos los beneficios de la tabla Beneficios
            //var todosLosBeneficios = _context.Beneficios.ToList();

            //// Obtener los beneficios que aún no tiene el usuario
            //var beneficiosDisponibles = todosLosBeneficios
            //    .Where(b => !beneficiosUsuario.Any(bu => bu.IdBeneficio == b.IdBeneficio))
            //    .ToList();

            //var model = new BeneficioViewModel
            //{
            //    // Beneficios que ya tiene el usuario
            //    Beneficios = beneficiosUsuario
            //        .Select(b => new SelectListItem
            //        {
            //            Value = b.IdBeneficio.ToString(),
            //            Text = b.Nombre
            //        })
            //        .ToList(),

            //    // Beneficios disponibles para agregar (se enviarán al frontend)
            //    BeneficiosDisponibles = beneficiosDisponibles
            //        .Select(b => new SelectListItem
            //        {
            //            Value = b.IdBeneficio.ToString(),
            //            Text = b.Nombre
            //        })
            //        .ToList(),

            //    BeneficiosSeleccionados = beneficiosUsuario.Select(b => b.IdBeneficio).ToList()
            //};
            var capacitacionVM = new CapacitacionViewModel
            {
                TipoCapacitacion = _context.CapacitacionTipoes
                    .Select(c => new SelectListItem
                    {
                        Value = c.IdCapacitacionTipo.ToString(),
                        Text = c.Descripcion
                    }).ToList()
            };

            return View(capacitacionVM);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCapacitaciones(CapacitacionViewModel model)
        {
            if (int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int currentUserId))
            {
              

                var capacitacionesUsuario = new List<CapacitacionUsuario>();

                foreach (var cap in model.Capacitaciones)
                {
                    capacitacionesUsuario.Add(new CapacitacionUsuario
                    {
                        IdCapacitacionTipo = cap.IdCapacitacionTipo,
                        Nombre = cap.Descripcion,
                        IdUsuario = currentUserId // Asignar el ID del usuario aquí
                    });
                }

                // Aquí se guardan en la base de datos
                _context.CapacitacionUsuarios.AddRange(capacitacionesUsuario);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index"); // Redirigir al index o donde sea necesario
        }


        [HttpPost]
        public IActionResult BeneficioCrear(BeneficioViewModel model)
        {
            if (int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int currentUserId))
            {
                ViewBag.CurrentUserId = currentUserId;
            }

            if (model.BeneficiosSeleccionados != null && model.BeneficiosSeleccionados.Any())
            {
                // Agregar los nuevos beneficios seleccionados a la tabla BeneficioUsuario
                var nuevosBeneficios = model.BeneficiosSeleccionados.Select(id => new BeneficioUsuario
                {
                    IdUsuarioInformacion = currentUserId,
                    IdBeneficio = id,
                    EstaAsignado = true
                });

                _context.BeneficioUsuarios.AddRange(nuevosBeneficios);
                _context.SaveChanges();
            }

            return RedirectToAction("Prueba");
        }




        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdBeneficio,Nombre,Descripcion")] Beneficio beneficio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(beneficio);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
            return View(beneficio);
        }

        public async Task<IActionResult> Modificar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficio = await _context.Beneficios.FindAsync(id);
            if (beneficio == null)
            {
                return NotFound();
            }
            return View(beneficio);
        }


        [HttpPost]
        public async Task<IActionResult> Modificar(int id, [Bind("IdBeneficio,Nombre,Descripcion")] Beneficio beneficio)
        {
            if (id != beneficio.IdBeneficio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beneficio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeneficioExist(beneficio.IdBeneficio))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(beneficio);
        }

        private bool BeneficioExist(int id)
        {
            return _context.Beneficios.Any(e => e.IdBeneficio == id);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            var beneficio = await _context.Beneficios.FindAsync(id);
            _context.Beneficios.Remove(beneficio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}