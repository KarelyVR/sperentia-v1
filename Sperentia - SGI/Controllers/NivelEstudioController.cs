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
    public class NivelEstudioController : Controller
    {

        private readonly SperientiaContext _context;

        public NivelEstudioController(SperientiaContext context)
        {
            _context = context;
        }

        // GET: Parametros
        public async Task<IActionResult> Index()
        {
            return View(await _context.NivelEstudios.ToListAsync());
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdNivelEstudio,Descripcion")] NivelEstudio nivelEstudio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(nivelEstudio);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
            return View(nivelEstudio);
        }

        public async Task<IActionResult> Modificar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudios = await _context.NivelEstudios.FindAsync(id);
            if (estudios == null)
            {
                return NotFound();
            }
            return View(estudios);
        }


        [HttpPost]
        public async Task<IActionResult> Modificar(int id, [Bind("IdNivelEstudio,Descripcion")] NivelEstudio nivelEstudio)
        {
            if (id != nivelEstudio.IdNivelEstudio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nivelEstudio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudioExist(nivelEstudio.IdNivelEstudio))
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
            return View(nivelEstudio);
        }

        private bool EstudioExist(int id)
        {
            return _context.NivelEstudios.Any(e => e.IdNivelEstudio == id);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            var estudios = await _context.NivelEstudios.FindAsync(id);
            _context.NivelEstudios.Remove(estudios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}