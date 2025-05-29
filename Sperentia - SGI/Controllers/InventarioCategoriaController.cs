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
    public class InventarioCategoriaController : Controller
    {

        private readonly SperientiaContext _context;

        public InventarioCategoriaController(SperientiaContext context)
        {
            _context = context;
        }

        // GET: Parametros
        public async Task<IActionResult> Index()
        {
            return View(await _context.InventarioCategorias.ToListAsync());
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdCategoria,Nombre")] InventarioCategoria inventarioCategoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(inventarioCategoria);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
            return View(inventarioCategoria);
        }

        public async Task<IActionResult> Modificar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventarioCategoria = await _context.InventarioCategorias.FindAsync(id);
            if (inventarioCategoria == null)
            {
                return NotFound();
            }
            return View(inventarioCategoria);
        }


        [HttpPost]
        public async Task<IActionResult> Modificar(int id, [Bind("IdCategoria,Nombre")] InventarioCategoria inventarioCategoria)
        {
            if (id != inventarioCategoria.IdCategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventarioCategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioCategoriaExist(inventarioCategoria.IdCategoria))
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
            return View(inventarioCategoria);
        }

        private bool InventarioCategoriaExist(int id)
        {
            return _context.InventarioCategorias.Any(e => e.IdCategoria == id);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            var inventarioCategoria = await _context.InventarioCategorias.FindAsync(id);
            _context.InventarioCategorias.Remove(inventarioCategoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}