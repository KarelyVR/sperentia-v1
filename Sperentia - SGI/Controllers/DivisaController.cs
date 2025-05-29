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
    public class DivisaController : Controller
    {

        private readonly SperientiaContext _context;

        public DivisaController(SperientiaContext context)
        {
            _context = context;
        }

        // GET: Parametros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Divisas.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdDivisa,Nombre,Codigo")] Divisa divisas)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(divisas);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
            return View(divisas);
        }

        public async Task<IActionResult> Modificar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divisa = await _context.Divisas.FindAsync(id);
            if (divisa == null)
            {
                return NotFound();
            }
            return View(divisa);
        }


        [HttpPost]
        public async Task<IActionResult> Modificar(int id, [Bind("IdDivisa,Nombre,Codigo")] Divisa divisas)
        {
            if (id != divisas.IdDivisa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(divisas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DivisaExist(divisas.IdDivisa))
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
            return View(divisas);
        }

        private bool DivisaExist(int id)
        {
            return _context.Divisas.Any(e => e.IdDivisa == id);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            var divisa = await _context.Divisas.FindAsync(id);
            _context.Divisas.Remove(divisa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}