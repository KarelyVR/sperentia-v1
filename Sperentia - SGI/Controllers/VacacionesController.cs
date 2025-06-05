using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Sperientia___SGI.Filtros;
using Sperientia___SGI.Models.dbModels;
using Sperientia___SGI.Models.dbModels.DbContext;
using Sperientia___SGI.ViewModel;
using System.Security.Claims;

namespace Sperientia___SGI.Controllers
{
    [ValidarAdmin]
    public class VacacionesController : Controller
    {
        private readonly SperientiaContext _context;

        public VacacionesController(SperientiaContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Solicitudes()
        {
            var solicitudes = await _context.SolicitudVacaciones
                .Include(x => x.SolicitudVacacionesEstatu)
                .Include(x => x.SolicitudVacacionesDias)
                .Include(x => x.UsuarioLogin_IdUsuarioRh)
                .Include(x => x.UsuarioLogin_IdEmpleado)
                .Include(x => x.UsuarioLogin_IdEmpleado)
                    .ThenInclude(x => x.UsuarioInformacion)
                .ToListAsync();

            var model = new VacacionesViewModel
            {
                Estatus = _context.SolicitudVacacionesEstatus
               .Select(b => new SelectListItem
               {
                   Value = b.IdEstatus.ToString(),
                   Text = b.Descripcion
               }).ToList(),
               Solicitudes = solicitudes
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Solicitudes(IFormCollection form)
        {
            int? estatusSeleccionado = string.IsNullOrEmpty(form["estatusId"]) ? (int?)null : Convert.ToInt32(form["estatusId"]);
            
            IQueryable<SolicitudVacaciones> query = _context.SolicitudVacaciones
                .Include(x => x.SolicitudVacacionesEstatu)
                .Include(x => x.SolicitudVacacionesDias)
                .Include(x => x.UsuarioLogin_IdUsuarioRh)
                .Include(x => x.UsuarioLogin_IdEmpleado)
                .Include(x => x.UsuarioLogin_IdEmpleado)
                    .ThenInclude(x => x.UsuarioInformacion);

            if (estatusSeleccionado.HasValue)
                query = query.Where(x => x.IdEstatus == estatusSeleccionado.Value);

           
            var solicitudFiltrada = await query.ToListAsync();

            var model = new VacacionesViewModel
            {
                Estatus = _context.SolicitudVacacionesEstatus
               .Select(b => new SelectListItem
               {
                   Value = b.IdEstatus.ToString(),
                   Text = b.Descripcion,
                   Selected = (estatusSeleccionado.HasValue && b.IdEstatus == estatusSeleccionado.Value)
               }).ToList(),
                Solicitudes = solicitudFiltrada
            };

            return View(model);
        }

        public async Task<IActionResult> Detalles(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await _context.SolicitudVacaciones
                .Include(x => x.SolicitudVacacionesEstatu)
                .Include(x => x.SolicitudVacacionesDias)
                .Include(x => x.UsuarioLogin_IdUsuarioRh)
                .Include(x => x.UsuarioLogin_IdEmpleado)
                .Include(x => x.UsuarioLogin_IdEmpleado)
                    .ThenInclude(x => x.UsuarioInformacion)
                .Include(x => x.UsuarioLogin_IdEmpleado)
                    .ThenInclude(x => x.UsuarioInformacion)
                        .ThenInclude(x => x.Empresa)
                .Include(x => x.UsuarioLogin_IdEmpleado)
                    .ThenInclude(x => x.UsuarioInformacion)
                        .ThenInclude(x => x.Departamento)
                .FirstOrDefaultAsync(m => m.IdSolicitud == id);

            if (solicitud == null)
            {
                return NotFound();
            }

            int diasAcumulados = _context.SolicitudVacacionesDias
                .Join(_context.SolicitudVacaciones,
                      dia => dia.IdSolicitud,
                      sol => sol.IdSolicitud,
                      (dia, sol) => new { dia, sol })
                .Where(x => x.sol.IdEmpleado == solicitud.IdEmpleado && x.sol.IdEstatus == 2)
                .Count();
            int diasPedidos = _context.SolicitudVacacionesDias
                    .Where(d => d.IdSolicitud == solicitud.IdSolicitud).Count();
            int diasRestantes = diasAcumulados == 0
                ? solicitud.DerechoDiasEmpleado - diasPedidos
                : solicitud.DerechoDiasEmpleado - diasAcumulados - diasPedidos;

            string alerta = diasRestantes < 0
                ? "¡Advertencia! Se han solicitado más días de los que se tiene disponibles."
                : null;

            var viewModel = new VacacionesViewModel
            {
                Vacaciones = solicitud,
                DiasPedidos = _context.SolicitudVacacionesDias
                    .Where(d => d.IdSolicitud == solicitud.IdSolicitud)
                    .OrderBy(d => d.Fecha) 
                    .ToList(),
                DiasAcumulados = diasAcumulados,
                DiasRestantes = diasRestantes,
                AlertaDiasRestantes = alerta
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarEstatus(int idSolicitud, int idEstatus)
        {
            int currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var solicitud = await _context.SolicitudVacaciones.FindAsync(idSolicitud);
            if (solicitud != null)
            {
                solicitud.IdUsuarioRh = currentUserId;
                solicitud.IdEstatus = idEstatus;
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Estatus de la solicitud actualizado correctamente";
            }

            return RedirectToAction("Solicitudes");
        }
    }
}
