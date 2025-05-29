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
    public class EstatusVacacionesController : Controller
    {

        private readonly SperientiaContext _context;

        public EstatusVacacionesController(SperientiaContext context)
        {
            _context = context;
        }

        // GET: Parametros
        public async Task<IActionResult> Index()
        {
            return View(await _context.SolicitudVacacionesEstatus.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdEstatus,Descripcion")] SolicitudVacacionesEstatus solicitudVacacionesEstatus)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(solicitudVacacionesEstatus);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
            return View(solicitudVacacionesEstatus);
        }

        public async Task<IActionResult> Modificar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estatus = await _context.SolicitudVacacionesEstatus.FindAsync(id);
            if (estatus == null)
            {
                return NotFound();
            }
            return View(estatus);
        }


        [HttpPost]
        public async Task<IActionResult> Modificar(int id, [Bind("IdEstatus,Descripcion")] SolicitudVacacionesEstatus solicitudVacacionesEstatus)
        {
            if (id != solicitudVacacionesEstatus.IdEstatus)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitudVacacionesEstatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstatusExist(solicitudVacacionesEstatus.IdEstatus))
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
            return View(solicitudVacacionesEstatus);
        }

        private bool EstatusExist(int id)
        {
            return _context.SolicitudVacacionesEstatus.Any(e => e.IdEstatus == id);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            var estatus = await _context.SolicitudVacacionesEstatus.FindAsync(id);
            _context.SolicitudVacacionesEstatus.Remove(estatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}