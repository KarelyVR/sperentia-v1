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
    public class PronombreController : Controller
    {

        private readonly SperientiaContext _context;

        public PronombreController(SperientiaContext context)
        {
            _context = context;
        }

        // GET: Parametros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pronombres.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdPronombre,Descripcion")] Pronombre pronombre)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(pronombre);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
            return View(pronombre);
        }

        public async Task<IActionResult> Modificar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pronombre = await _context.Pronombres.FindAsync(id);
            if (pronombre == null)
            {
                return NotFound();
            }
            return View(pronombre);
        }


        [HttpPost]
        public async Task<IActionResult> Modificar(int id, [Bind("IdPronombre,Descripcion")] Pronombre pronombre)
        {
            if (id != pronombre.IdPronombre)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pronombre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PronombreExist(pronombre.IdPronombre))
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
            return View(pronombre);
        }

        private bool PronombreExist(int id)
        {
            return _context.Pronombres.Any(e => e.IdPronombre == id);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            var pronombre = await _context.Pronombres.FindAsync(id);
            _context.Pronombres.Remove(pronombre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}