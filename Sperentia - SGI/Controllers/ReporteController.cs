using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sperientia___SGI.Models.dbModels.DbContext;
using Sperientia___SGI.Models.dbModels;
using Sperientia___SGI.ViewModel;

namespace Sperientia___SGI.Controllers
{
    public class ReporteController : Controller
    {
        private readonly SperientiaContext _context;

        public ReporteController(SperientiaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Empleado()
        {

            var usuario = await _context.UsuarioInformacions
                    .Include(d => d.UsuarioLogin_IdUsuarioLogin)
                    .Include(d => d.Pronombre)
                    .Include(d => d.EstadoCivil)
                    .Include(d => d.Pai)
                    .Include(d => d.TallaPlayera)
                    .Include(d => d.NivelEstudio)
                    .Include(d => d.TipoContrato)
                    .Include(d => d.Empresa)
                    .Include(d => d.Departamento)
                    .Include(d => d.Divisa)
                    .ToListAsync();

            // Cargar listas como en Create
            var personalVM = new PersonalViewModel
            {
                Pais = _context.Pais.Select(e => new SelectListItem
                {
                    Value = e.IdPais.ToString(),
                    Text = e.Nombre
                }).ToList()
            };

            var empresarialVM = new EmpresarialViewModel
            {
                Empresa = _context.Empresas.Select(e => new SelectListItem
                {
                    Value = e.IdEmpresa.ToString(),
                    Text = e.Nombre
                }).ToList(),
                Departamento = _context.Departamentoes.Select(d => new SelectListItem
                {
                    Value = d.IdDepartamento.ToString(),
                    Text = d.Nombre
                }).ToList()
            };

            var model = new ContenedorViewModel
            {
                Empleados = usuario,
                Personal = personalVM,
                Empresarial = empresarialVM
            };

            return View(model);
        }

        public IActionResult ReporteVacaciones()
        {
            return View();
        }

        public async Task<IActionResult> Inventario()
        {
            var inventarioinfo = await _context.InventarioAsignacions
                    .Include(d => d.UsuarioLogin)
                    .Include(d => d.UsuarioLogin)
                       .ThenInclude(d => d.UsuarioInformacion)
                    .Include(d => d.UsuarioLogin)
                       .ThenInclude(d => d.UsuarioInformacion)
                           .ThenInclude(d => d.Empresa)
                    .Include(d => d.Inventario)
                    .Include(d => d.Inventario)
                        .ThenInclude(d => d.InventarioCategoria)
                    .ToListAsync();


            var inventarioVM = new InventarioViewModel
            {
                InventarioCategoria = _context.InventarioCategorias
               .Select(b => new SelectListItem
               {
                   Value = b.IdCategoria.ToString(),
                   Text = b.Nombre
               }).ToList(),
                Usuarios = _context.Users
                   .Select(t => new SelectListItem
                   {
                       Value = t.Id.ToString(),
                       Text = t.NombreCompleto
                   })
               .ToList(),
                InventarioUsr = inventarioinfo
            };

            return View(inventarioVM);

        }

        public async Task<IActionResult> Servicios()
        {
            var servicioinfo = await _context.ServicioUsuarios
                     .Include(d => d.UsuarioLogin)
                     .Include(d => d.UsuarioLogin)
                        .ThenInclude(d => d.UsuarioInformacion)
                     .Include(d => d.UsuarioLogin)
                        .ThenInclude(d => d.UsuarioInformacion)
                            .ThenInclude(d => d.Empresa)
                     .Include(d => d.Servicio)
                     .ToListAsync();


            var servicioVM = new ServiciosViewModel
            {
                Servicios = _context.Servicios
               .Select(b => new SelectListItem
               {
                   Value = b.IdServicio.ToString(),
                   Text = b.Nombre
               }).ToList(),
                Usuarios = _context.Users
                   .Select(t => new SelectListItem
                   {
                       Value = t.Id.ToString(),
                       Text = t.NombreCompleto
                   })
               .ToList(),
                ServicioInfoUsr = servicioinfo
            };

            return View(servicioVM);

        }

        [HttpPost]
        public async Task<IActionResult> Empleado(IFormCollection form)
        {
            int? paisSeleccionado = string.IsNullOrEmpty(form["paisid"]) ? (int?)null : Convert.ToInt32(form["paisid"]);
            int? empresaSeleccionada = string.IsNullOrEmpty(form["empresaid"]) ? (int?)null : Convert.ToInt32(form["empresaid"]);
            int? departamentoSeleccionado = string.IsNullOrEmpty(form["departamentoid"]) ? (int?)null : Convert.ToInt32(form["departamentoid"]);

            IQueryable<UsuarioInformacion> query = _context.UsuarioInformacions
                .Include(l => l.Pai)
                .Include(l => l.Empresa)
                .Include(l => l.Departamento)
                .Include(d => d.UsuarioLogin_IdUsuarioLogin);

            if (paisSeleccionado.HasValue)
                query = query.Where(x => x.IdPais == paisSeleccionado.Value);

            if (empresaSeleccionada.HasValue)
                query = query.Where(x => x.IdEmpresa == empresaSeleccionada.Value);

            if (departamentoSeleccionado.HasValue)
                query = query.Where(x => x.IdDepartamento == departamentoSeleccionado.Value);

            var empleadosFiltrados = await query.ToListAsync();

            var personalVM = new PersonalViewModel
            {
                Pais = _context.Pais.Select(e => new SelectListItem
                {
                    Value = e.IdPais.ToString(),
                    Text = e.Nombre,
                    Selected = (paisSeleccionado.HasValue && e.IdPais == paisSeleccionado.Value)
                }).ToList()
            };

            var empresarialVM = new EmpresarialViewModel
            {
                Empresa = _context.Empresas.Select(e => new SelectListItem
                {
                    Value = e.IdEmpresa.ToString(),
                    Text = e.Nombre,
                    Selected = (empresaSeleccionada.HasValue && e.IdEmpresa == empresaSeleccionada.Value)
                }).ToList(),
                Departamento = _context.Departamentoes.Select(d => new SelectListItem
                {
                    Value = d.IdDepartamento.ToString(),
                    Text = d.Nombre,
                    Selected = (departamentoSeleccionado.HasValue && d.IdDepartamento == departamentoSeleccionado.Value)
                }).ToList()
            };

            var model = new ContenedorViewModel
            {
                Empleados = empleadosFiltrados,
                Personal = personalVM,
                Empresarial = empresarialVM
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Inventario(IFormCollection form)
        {
            int? empleadoSeleccionado = string.IsNullOrEmpty(form["empleadoid"]) ? (int?)null : Convert.ToInt32(form["empleadoid"]);
            int? categoriaSeleccionada = string.IsNullOrEmpty(form["categoriaid"]) ? (int?)null : Convert.ToInt32(form["categoriaid"]);

            IQueryable<InventarioAsignacion> query = _context.InventarioAsignacions
                  .Include(d => d.UsuarioLogin)
                    .Include(d => d.UsuarioLogin)
                       .ThenInclude(d => d.UsuarioInformacion)
                    .Include(d => d.UsuarioLogin)
                       .ThenInclude(d => d.UsuarioInformacion)
                           .ThenInclude(d => d.Empresa)
                    .Include(d => d.Inventario)
                    .Include(d => d.Inventario)
                        .ThenInclude(d => d.InventarioCategoria);

            if (empleadoSeleccionado.HasValue)
                query = query.Where(x => x.IdUsuario == empleadoSeleccionado.Value);

            if (categoriaSeleccionada.HasValue)
                query = query.Where(x => x.Inventario.IdCategoria == categoriaSeleccionada.Value);

            var inventarioFiltrado = await query.ToListAsync();

            var inventarioVM = new InventarioViewModel
            {
                InventarioCategoria = _context.InventarioCategorias
               .Select(b => new SelectListItem
               {
                   Value = b.IdCategoria.ToString(),
                   Text = b.Nombre,
                   Selected = (categoriaSeleccionada.HasValue && b.IdCategoria == categoriaSeleccionada.Value)
               }).ToList(),
                Usuarios = _context.Users
                   .Select(t => new SelectListItem
                   {
                       Value = t.Id.ToString(),
                       Text = t.NombreCompleto,
                       Selected = (empleadoSeleccionado.HasValue && t.Id == empleadoSeleccionado.Value)
                   })
               .ToList(),
                InventarioUsr = inventarioFiltrado
            };

            return View(inventarioVM);
        }

        [HttpPost]
        public async Task<IActionResult> Servicios(IFormCollection form)
        {
            int? empleadoSeleccionado = string.IsNullOrEmpty(form["empleadoid"]) ? (int?)null : Convert.ToInt32(form["empleadoid"]);
            int? servicioSeleccionado = string.IsNullOrEmpty(form["servicioid"]) ? (int?)null : Convert.ToInt32(form["servicioid"]);

            IQueryable<ServicioUsuario> query = _context.ServicioUsuarios
                  .Include(d => d.UsuarioLogin)
                     .Include(d => d.UsuarioLogin)
                        .ThenInclude(d => d.UsuarioInformacion)
                     .Include(d => d.UsuarioLogin)
                        .ThenInclude(d => d.UsuarioInformacion)
                            .ThenInclude(d => d.Empresa)
                     .Include(d => d.Servicio);

            if (empleadoSeleccionado.HasValue)
                query = query.Where(x => x.IdUsuario == empleadoSeleccionado.Value);

            if (servicioSeleccionado.HasValue)
                query = query.Where(x => x.Servicio.IdServicio == servicioSeleccionado.Value);

            var servicioFiltrado = await query.ToListAsync();

            var servicioVM = new ServiciosViewModel
            {
                Servicios = _context.Servicios
               .Select(b => new SelectListItem
               {
                   Value = b.IdServicio.ToString(),
                   Text = b.Nombre,
                   Selected = (servicioSeleccionado.HasValue && b.IdServicio == servicioSeleccionado.Value)
               }).ToList(),
                            Usuarios = _context.Users
                   .Select(t => new SelectListItem
                   {
                       Value = t.Id.ToString(),
                       Text = t.NombreCompleto,
                       Selected = (empleadoSeleccionado.HasValue && t.Id == empleadoSeleccionado.Value)
                   })
               .ToList(),
                ServicioInfoUsr = servicioFiltrado
            };


            return View(servicioVM);
        }
    }
}
