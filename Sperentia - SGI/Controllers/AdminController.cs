using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sperientia___SGI.Models.dbModels;
using Sperientia___SGI.Models.dbModels.DbContext;
using Sperientia___SGI.ViewModel;
using System.Security.Claims;

namespace Sperientia___SGI.Controllers
{
    public class AdminController : Controller
    {

        private readonly SperientiaContext _context;

        public AdminController(SperientiaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public async Task<IActionResult> PerfilUsuario()
        {
            //var usuarioActual = await _userManager.GetUserAsync(User);
            int id = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var usuario = await _context.UsuarioInformacions
               .Include(d => d.Pronombre)
               .Include(d => d.EstadoCivil)
               .Include(d => d.Pai)
               .Include(d => d.TallaPlayera)
               .Include(d => d.NivelEstudio)
               .Include(d => d.TipoContrato)
               .Include(d => d.Empresa)
               .Include(d => d.Departamento)
               .Include(d => d.Divisa)
               .Include(d => d.UsuarioLogin_IdUsuarioLogin)
               .FirstOrDefaultAsync(m => m.IdUsuarioLogin == id);

            if (usuario == null)
            {
                return NotFound();
            }

            // Buscar info relacionada por Id
            var beneficio = await _context.BeneficioUsuarios.
                Where(x => x.IdUsuarioInformacion == id)
                .Include(x => x.Beneficio)
                .ToListAsync();

            var capacitacion = await _context.CapacitacionUsuarios.
                Where(x => x.IdUsuario == id)
                .Include(x => x.CapacitacionTipo)
                .ToListAsync();

            var direccion = await _context.Direccions.FirstOrDefaultAsync(x => x.IdUsuario == id)
                ?? new Direccion();


            var viewModel = new ContenedorViewModel
            {
                UsuarioInformacion = usuario,
                Beneficios = beneficio,
                Capacitaciones = capacitacion,
                Direccion = direccion
            };

            return View(viewModel);
        }

        public async Task<IActionResult> VacacionesEmpleado()
        {
            int id = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var vacacionesE = await _context.SolicitudVacaciones
                .Include(x => x.SolicitudVacacionesEstatu)
                .Include(x => x.SolicitudVacacionesDias)
                .Include(x => x.UsuarioLogin_IdEmpleado)
                .Include(x => x.UsuarioLogin_IdUsuarioRh)
                    .Where(x => x.IdEmpleado == id)
                    .ToListAsync();

            // Obtener el UsuarioInformacion relacionado
            var usuarioInfo = await _context.UsuarioInformacions
                .Include(u => u.UsuarioLogin_IdUsuarioLogin)
                .FirstOrDefaultAsync(u => u.UsuarioLogin_IdUsuarioLogin.Id == id);

            int diasDisponibles = usuarioInfo?.DiasDisponiblesVacaciones ?? 0;

            var viewModel = new VacacionesViewModel
            {
                Solicitudes = vacacionesE,
                Usuarios = _context.UsuarioInformacions
                   .Select(b => new SelectListItem
                   {
                       Value = b.UsuarioLogin_IdUsuarioLogin.Id.ToString(),
                       Text = b.UsuarioLogin_IdUsuarioLogin.NombreCompleto
                   }).ToList(),
                VacacionSolicitud = new SolicitudVacaciones
                {
                    IdEmpleado = id,
                    IdEstatus = 1,
                    DerechoDiasEmpleado = diasDisponibles,
                    FechaSolicitud = DateTime.Today
                },
                DiasDisponiblesVacaciones = diasDisponibles
            };

            return View(viewModel);
        }

        public async Task<IActionResult> InventarioEmpleado()
        {
            int id = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var inventarioA = await _context.InventarioAsignacions
                .Include(x => x.UsuarioLogin)
                .Include(x => x.Inventario)
                .Include(x => x.Inventario)
                    .ThenInclude(x => x.InventarioCategoria)
                .Where(x => x.IdUsuario == id)
                .ToListAsync();


            return View(inventarioA);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarSolicitud(VacacionesViewModel model, string Fechas)
        {
            try
            {

                _context.SolicitudVacaciones.Add(model.VacacionSolicitud);
                await _context.SaveChangesAsync();

                var solicitudId = model.VacacionSolicitud.IdSolicitud;

                if (!string.IsNullOrEmpty(Fechas))
                {
                    var fechasList = Fechas
                       .Split(',')
                       .Select(d => DateTime.Parse(d))
                       .ToList();

                    foreach (var fecha in fechasList)
                    {
                        var dia = new SolicitudVacacionesDia
                        {
                            Fecha = fecha,
                            IdSolicitud = solicitudId 
                        };

                        _context.SolicitudVacacionesDias.Add(dia);

                    }
                    await _context.SaveChangesAsync(); 

                }

            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
             
            }
            return RedirectToAction("VacacionesEmpleado");
        }

    }
}
