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
    public class TipoContratoController : Controller
    {

        private readonly SperientiaContext _context;

        public TipoContratoController(SperientiaContext context)
        {
            _context = context;
        }

        // GET: Parametros
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoContratoes.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdTipoContrato,Descripcion")] TipoContrato tipoContrato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(tipoContrato);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
            return View(tipoContrato);
        }

        public async Task<IActionResult> Modificar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoContrato = await _context.TipoContratoes.FindAsync(id);
            if (tipoContrato == null)
            {
                return NotFound();
            }
            return View(tipoContrato);
        }


        [HttpPost]
        public async Task<IActionResult> Modificar(int id, [Bind("IdTipoContrato,Descripcion")] TipoContrato tipoContrato)
        {
            if (id != tipoContrato.IdTipoContrato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoContrato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoExist(tipoContrato.IdTipoContrato))
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
            return View(tipoContrato);
        }

        private bool ContratoExist(int id)
        {
            return _context.TipoContratoes.Any(e => e.IdTipoContrato == id);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            var tipoContrato = await _context.TipoContratoes.FindAsync(id);
            _context.TipoContratoes.Remove(tipoContrato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}