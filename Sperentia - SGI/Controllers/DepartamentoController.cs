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

    public class DepartamentoController : Controller
    {

        private readonly SperientiaContext _context;

        public DepartamentoController(SperientiaContext context)
        {
            _context = context;
        }

        // GET: Parametros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Departamentoes.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdDepartamento,Nombre")] Departamento departamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(departamento);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
            return View(departamento);
        }

        public async Task<IActionResult> Modificar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamentoes.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }


        [HttpPost]
        public async Task<IActionResult> Modificar(int id, [Bind("IdDepartamento,Nombre")] Departamento departamento)
        {
            if (id != departamento.IdDepartamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentoExist(departamento.IdDepartamento))
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
            return View(departamento);
        }

        private bool DepartamentoExist(int id)
        {
            return _context.Departamentoes.Any(e => e.IdDepartamento == id);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            var departamento = await _context.Departamentoes.FindAsync(id);
            _context.Departamentoes.Remove(departamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}