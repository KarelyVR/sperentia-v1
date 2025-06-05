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
using Sperientia___SGI.Filtros;

namespace MultasTransito.Controllers
{
    [ValidarAdmin]
    public class EstadoCivilController : Controller
    {

        private readonly SperientiaContext _context;

        public EstadoCivilController(SperientiaContext context)
        {
            _context = context;
        }

        // GET: Parametros
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoCivils.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdEstadoCivil,Descripcion")] EstadoCivil estadoCivil)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(estadoCivil);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
            return View(estadoCivil);
        }

        public async Task<IActionResult> Modificar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoCivil = await _context.EstadoCivils.FindAsync(id);
            if (estadoCivil == null)
            {
                return NotFound();
            }
            return View(estadoCivil);
        }


        [HttpPost]
        public async Task<IActionResult> Modificar(int id, [Bind("IdEstadoCivil,Descripcion")] EstadoCivil estadoCivil)
        {
            if (id != estadoCivil.IdEstadoCivil)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoCivil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoCivilExist(estadoCivil.IdEstadoCivil))
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
            return View(estadoCivil);
        }

        private bool EstadoCivilExist(int id)
        {
            return _context.EstadoCivils.Any(e => e.IdEstadoCivil == id);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            var estadoCivil = await _context.EstadoCivils.FindAsync(id);
            _context.EstadoCivils.Remove(estadoCivil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}