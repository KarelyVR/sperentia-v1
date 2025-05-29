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
    public class TallaPlayeraController : Controller
    {

        private readonly SperientiaContext _context;

        public TallaPlayeraController(SperientiaContext context)
        {
            _context = context;
        }

        // GET: Parametros
        public async Task<IActionResult> Index()
        {
            return View(await _context.TallaPlayeras.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdTallaPlayera,Talla")] TallaPlayera tallaPlayera)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(tallaPlayera);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
            return View(tallaPlayera);
        }

        public async Task<IActionResult> Modificar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playera = await _context.TallaPlayeras.FindAsync(id);
            if (playera == null)
            {
                return NotFound();
            }
            return View(playera);
        }


        [HttpPost]
        public async Task<IActionResult> Modificar(int id, [Bind("IdTallaPlayera,Talla")] TallaPlayera tallaPlayera)
        {
            if (id != tallaPlayera.IdTallaPlayera)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tallaPlayera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TallaExist(tallaPlayera.IdTallaPlayera))
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
            return View(tallaPlayera);
        }

        private bool TallaExist(int id)
        {
            return _context.TallaPlayeras.Any(e => e.IdTallaPlayera == id);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            var playera = await _context.TallaPlayeras.FindAsync(id);
            _context.TallaPlayeras.Remove(playera);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}