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

namespace MultasTransito.Controllers
{
    public class CapacitacionController : Controller
    {

        private readonly SperientiaContext _context;

        public CapacitacionController(SperientiaContext context)
        {
            _context = context;
        }

        // GET: Parametros
        public async Task<IActionResult> Index()
        {
            return View(await _context.CapacitacionTipoes.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdCapacitacionTipo,Descripcion")] CapacitacionTipo capacitacionTipo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(capacitacionTipo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
            return View(capacitacionTipo);
        }

        public async Task<IActionResult> Modificar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capacitacion = await _context.CapacitacionTipoes.FindAsync(id);
            if (capacitacion == null)
            {
                return NotFound();
            }
            return View(capacitacion);
        }


        [HttpPost]
        public async Task<IActionResult> Modificar(int id, [Bind("IdCapacitacionTipo,Descripcion")] CapacitacionTipo capacitacionTipo)
        {
            if (id != capacitacionTipo.IdCapacitacionTipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(capacitacionTipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CapacitacionExist(capacitacionTipo.IdCapacitacionTipo))
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
            return View(capacitacionTipo);
        }

        private bool CapacitacionExist(int id)
        {
            return _context.CapacitacionTipoes.Any(e => e.IdCapacitacionTipo == id);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            var capacitacion = await _context.CapacitacionTipoes.FindAsync(id);
            _context.CapacitacionTipoes.Remove(capacitacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}