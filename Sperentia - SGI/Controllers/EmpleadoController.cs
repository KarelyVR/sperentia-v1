using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Sperientia___SGI.Models.dbModels;
using Sperientia___SGI.Models.dbModels.DbContext;
using Sperientia___SGI.ViewModel;
using System.Security.Claims;

namespace Sperientia___SGI.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly SperientiaContext _context;

        public EmpleadoController(SperientiaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var empleados = await _context.UsuarioInformacions
                .Include(x => x.TipoContrato)
                .Include(x => x.Empresa)
                .Include(x => x.UsuarioLogin_IdUsuarioLogin)
                .Include(x => x.Departamento)
                .ToListAsync();


            return View(empleados);

            //return View(await _context.UsuarioInformacions.ToListAsync());
        }

        public IActionResult Create()
        {
            if (int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int currentUserId))
            {
                ViewBag.CurrentUserId = currentUserId;
            }

            var beneficioVM = new BeneficioViewModel
            {
                Beneficios = _context.Beneficios
                    .Select(b => new SelectListItem
                    {
                        Value = b.IdBeneficio.ToString(),
                        Text = b.Nombre
                    }).ToList(),
                BeneficiosSeleccionados = new List<int>()
            };

            var capacitacionVM = new CapacitacionViewModel
            {
                TipoCapacitacion = _context.CapacitacionTipoes
                    .Select(c => new SelectListItem
                    {
                        Value = c.IdCapacitacionTipo.ToString(),
                        Text = c.Descripcion
                    }).ToList()
            };

            var personalVM = new PersonalViewModel
            {
                Usuarios = _context.Users
                    .Where(t => !_context.UsuarioInformacions
                        .Select(u => u.IdUsuarioLogin)
                        .Contains(t.Id))
                    .Select(t => new SelectListItem
                    {
                        Value = t.Id.ToString(),
                        Text = t.NombreCompleto
                    })
                .ToList(),
                Pais = _context.Pais.Select(e => new SelectListItem
                {
                    Value = e.IdPais.ToString(),
                    Text = e.Nombre
                }).ToList(),
                Playera = _context.TallaPlayeras.Select(d => new SelectListItem
                {
                    Value = d.IdTallaPlayera.ToString(),
                    Text = d.Talla
                }).ToList(),
                Pronombres = _context.Pronombres.Select(d => new SelectListItem
                {
                    Value = d.IdPronombre.ToString(),
                    Text = d.Descripcion
                }).ToList(),
                EstadoCivil = _context.EstadoCivils.Select(t => new SelectListItem
                {
                    Value = t.IdEstadoCivil.ToString(),
                    Text = t.Descripcion
                }).ToList(),
                NivelEstudio = _context.NivelEstudios.Select(t => new SelectListItem
                {
                    Value = t.IdNivelEstudio.ToString(),
                    Text = t.Descripcion
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
                }).ToList(),
                Divisa = _context.Divisas.Select(d => new SelectListItem
                {
                    Value = d.IdDivisa.ToString(),
                    Text = d.Nombre
                }).ToList(),
                TipoContrato = _context.TipoContratoes.Select(t => new SelectListItem
                {
                    Value = t.IdTipoContrato.ToString(),
                    Text = t.Descripcion
                }).ToList(),
                Supervisor = _context.Users.Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.NombreCompleto
                }).ToList()
            };

            var model = new ContenedorViewModel
            {
                Beneficio = beneficioVM,
                Capacitacion = capacitacionVM,
                Personal = personalVM,
                Empresarial = empresarialVM,
                UsuarioInformacion = new UsuarioInformacion()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(ContenedorViewModel model)
        {
            var rutaBase = Path.Combine(Directory.GetCurrentDirectory(), "ArchivosPrivados/Empleados/Documentos");
            var archivosGuardados = new List<string>();

            try
            {
                if (int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int currentUserId))
                {
                    var userId = model.UsuarioInformacion.IdUsuarioLogin;
                    var baseD = Directory.GetCurrentDirectory();

                    if (!Directory.Exists(rutaBase))
                        Directory.CreateDirectory(rutaBase);

                    // Guardar Curriculum
                    if (model.CurriculumFile != null && model.CurriculumFile.Length > 0)
                    {
                        var nombreArchivo = $"curriculum_{userId}_{Path.GetFileName(model.CurriculumFile.FileName)}";
                        var rutaCompleta = Path.Combine(rutaBase, nombreArchivo);

                        using (var stream = new FileStream(rutaCompleta, FileMode.Create))
                        {
                            await model.CurriculumFile.CopyToAsync(stream);
                        }

                        model.UsuarioInformacion.CurriculumVitaeUrl = $"/archivosPrivados/Empleados/Documentos/{nombreArchivo}";
                    }

                    // Guardar Acta de Nacimiento
                    if (model.ActaNacimientoFile != null && model.ActaNacimientoFile.Length > 0)
                    {
                        var nombreArchivo = $"acta_{userId}_{Path.GetFileName(model.ActaNacimientoFile.FileName)}";
                        var rutaCompleta = Path.Combine(rutaBase, nombreArchivo);

                        using (var stream = new FileStream(rutaCompleta, FileMode.Create))
                        {
                            await model.ActaNacimientoFile.CopyToAsync(stream);
                        }

                        model.UsuarioInformacion.ActaNacimientoUrl = $"/archivosPrivados/Empleados/Documentos/{nombreArchivo}";
                    }

                    // Guardar Comprobante 
                    if (model.ComprobanteDom != null && model.ComprobanteDom.Length > 0)
                    {
                        var nombreArchivo = $"comprobante_{userId}_{Path.GetFileName(model.ComprobanteDom.FileName)}";
                        var rutaCompleta = Path.Combine(rutaBase, nombreArchivo);

                        using (var stream = new FileStream(rutaCompleta, FileMode.Create))
                        {
                            await model.ComprobanteDom.CopyToAsync(stream);
                        }

                        model.Direccion.ComprobanteDomicilioUrl = $"/archivosPrivados/Empleados/Documentos/{nombreArchivo}";
                    }

                    //guardar datos empleado
                    model.UsuarioInformacion.IdUsuarioLogin = userId;
                    _context.UsuarioInformacions.Add(model.UsuarioInformacion);

                    //guardar direccion
                    model.Direccion.IdUsuario = userId;
                    _context.Direccions.Add(model.Direccion);

                    //guardar capacitaciones
                    //if (model.Capacitacion.Capacitaciones != null && model.Capacitacion.Capacitaciones.Any())
                    if (model.Capacitacion?.Capacitaciones?.Any() == true)
                    {
                        var capacitacionesUsuario = new List<CapacitacionUsuario>();

                        foreach (var cap in model.Capacitacion.Capacitaciones)
                        {
                            capacitacionesUsuario.Add(new CapacitacionUsuario
                            {
                                IdCapacitacionTipo = cap.IdCapacitacionTipo,
                                Nombre = cap.Descripcion,
                                IdUsuario = userId
                            });
                        }
                        _context.CapacitacionUsuarios.AddRange(capacitacionesUsuario);
                    }


                    //guardar beneficios seleccionados
                    if (model.Beneficio?.BeneficiosSeleccionados?.Any() == true)
                    {
                        var nuevosBeneficios = model.Beneficio.BeneficiosSeleccionados.Select(id => new BeneficioUsuario
                        {
                            IdUsuarioInformacion = userId,
                            IdBeneficio = id,
                            EstaAsignado = true
                        });
                        _context.BeneficioUsuarios.AddRange(nuevosBeneficios);
                    }

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                foreach (var archivo in archivosGuardados)
                {
                    if (System.IO.File.Exists(archivo))
                    {
                        System.IO.File.Delete(archivo);
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detalles(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

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
                .Include(d => d.UsuarioLogin_IdSupervisor)
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

        public async Task<IActionResult> Modificar(int? id)
        {
            if (int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int currentUserId))
            {
                if (id == null)
                    return NotFound();

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
                    .FirstOrDefaultAsync(m => m.IdUsuarioLogin == id);

                if (usuario == null)
                    return NotFound();

                // Cargar listas como en Create
                var personalVM = new PersonalViewModel
                {
                    Usuarios = _context.Users.Select(t => new SelectListItem
                    {
                        Value = t.Id.ToString(),
                        Text = t.NombreCompleto
                    }).ToList(),
                    Pais = _context.Pais.Select(e => new SelectListItem
                    {
                        Value = e.IdPais.ToString(),
                        Text = e.Nombre
                    }).ToList(),
                    Playera = _context.TallaPlayeras.Select(d => new SelectListItem
                    {
                        Value = d.IdTallaPlayera.ToString(),
                        Text = d.Talla
                    }).ToList(),
                    Pronombres = _context.Pronombres.Select(d => new SelectListItem
                    {
                        Value = d.IdPronombre.ToString(),
                        Text = d.Descripcion
                    }).ToList(),
                    EstadoCivil = _context.EstadoCivils.Select(t => new SelectListItem
                    {
                        Value = t.IdEstadoCivil.ToString(),
                        Text = t.Descripcion
                    }).ToList(),
                    NivelEstudio = _context.NivelEstudios.Select(t => new SelectListItem
                    {
                        Value = t.IdNivelEstudio.ToString(),
                        Text = t.Descripcion
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
                    }).ToList(),
                    Divisa = _context.Divisas.Select(d => new SelectListItem
                    {
                        Value = d.IdDivisa.ToString(),
                        Text = d.Nombre
                    }).ToList(),
                    TipoContrato = _context.TipoContratoes.Select(t => new SelectListItem
                    {
                        Value = t.IdTipoContrato.ToString(),
                        Text = t.Descripcion
                    }).ToList(),
                    Supervisor = _context.Users.Select(t => new SelectListItem
                    {
                        Value = t.Id.ToString(),
                        Text = t.NombreCompleto
                    }).ToList()
                };

                var beneficio = await _context.BeneficioUsuarios
                    .Where(x => x.IdUsuarioInformacion == id)
                    .Select(x => x.IdBeneficio)
                    .ToListAsync();

                var beneficioVM = new BeneficioViewModel
                {
                    Beneficios = _context.Beneficios
                        .Select(b => new SelectListItem
                        {
                            Value = b.IdBeneficio.ToString(),
                            Text = b.Nombre
                        }).ToList(),
                    BeneficiosSeleccionados = beneficio
                };

                var capacitaciones = await _context.CapacitacionUsuarios.
                Where(x => x.IdUsuario == id)
                .Include(x => x.CapacitacionTipo)
                .ToListAsync();

                // IDs de capacitaciones ya asignadas
                var yaAsignadasIds = capacitaciones
                    .Select(c => c.IdCapacitacionTipo)
                    .ToList();

                var todas = await _context.CapacitacionTipoes.ToListAsync();

                var capacitacionVM = new CapacitacionViewModel
                {
                    TipoCapacitacion = todas
                        .Where(c => !yaAsignadasIds.Contains(c.IdCapacitacionTipo))
                        .Select(c => new SelectListItem
                        {
                            Value = c.IdCapacitacionTipo.ToString(),
                            Text = c.Descripcion
                        }).ToList()
                };

                var direccion = await _context.Direccions.FirstOrDefaultAsync(x => x.IdUsuario == id)
                    ?? new Direccion();

                var model = new ContenedorViewModel
                {
                    UsuarioInformacion = usuario,
                    Personal = personalVM,
                    Empresarial = empresarialVM,
                    Beneficio = beneficioVM,
                    Capacitacion = capacitacionVM,
                    Capacitaciones = capacitaciones,
                    Direccion = direccion
                };

                return View(model);
            }
            return View();

        }

        public IActionResult VerDocumento(string rutaArchivo)
        {
            var baseD = Directory.GetCurrentDirectory();
            var archivoRelativo = rutaArchivo.TrimStart('/', '\\');
            var ruta = Path.Combine(baseD, archivoRelativo);

            if (!System.IO.File.Exists(ruta))
            {
                return NotFound("Archivo no encontrado.");
            }

            var mimeType = "application/pdf";
            var fileBytes = System.IO.File.ReadAllBytes(ruta);

            var nombreAuto = "Documento_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + Path.GetExtension(ruta);

            return File(fileBytes, mimeType, nombreAuto);
        }

        [HttpPost]
        public async Task<IActionResult> ModificarRegistro(ContenedorViewModel model)
        {

            var rutaBase = Path.Combine(Directory.GetCurrentDirectory(), "ArchivosPrivados/Empleados/Documentos");
            var archivosGuardados = new List<string>();
            var archivosAnteriores = new List<string>();

            try
            {
                await ProcesarArchivos(model, rutaBase, archivosGuardados, archivosAnteriores);
                await ActualizarUsuarioInformacion(model);
                await ActualizarDireccion(model);
                await ActualizarCapacitaciones(model);
                await ActualizarBeneficios(model);

                await _context.SaveChangesAsync();

                foreach (var ruta in archivosAnteriores)
                {
                    if (System.IO.File.Exists(ruta))
                        System.IO.File.Delete(ruta);
                }

                TempData["SuccessMessage"] = "Registro actualizado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al actualizar el registro");
                foreach (var ruta in archivosGuardados)
                {
                    if (System.IO.File.Exists(ruta))
                    {
                        System.IO.File.Delete(ruta);
                    }
                }
                return RedirectToAction("Index");
            }
        }

        private async Task ProcesarArchivos(ContenedorViewModel model, string rutaBase, List<string> archivosGuardados, List<string> archivosAnteriores)
        {
            var userId = model.UsuarioInformacion.IdUsuarioLogin;

            // CV
            if (model.CurriculumFile != null && model.CurriculumFile.Length > 0)
            {
                var nombreCorto = Convert.ToBase64String(Guid.NewGuid().ToByteArray())
                    .Replace("=", "").Replace("+", "").Replace("/", "") // Quitar caracteres especiales
                    .Substring(0, 8);
                var nuevoNombre = $"cv_{userId}_{nombreCorto}{Path.GetExtension(model.CurriculumFile.FileName)}";
                var nuevaRuta = Path.Combine(rutaBase, nuevoNombre);

                // Guardar el anterior si existe
                if (!string.IsNullOrEmpty(model.UsuarioInformacion.CurriculumVitaeUrl))
                {
                    var anteriorRuta = Path.Combine(rutaBase, Path.GetFileName(model.UsuarioInformacion.CurriculumVitaeUrl));
                    if (System.IO.File.Exists(anteriorRuta))
                        archivosAnteriores.Add(anteriorRuta);
                }

                using (var stream = new FileStream(nuevaRuta, FileMode.Create))
                    await model.CurriculumFile.CopyToAsync(stream);

                model.UsuarioInformacion.CurriculumVitaeUrl = $"/archivosPrivados/Empleados/Documentos/{nuevoNombre}";
                archivosGuardados.Add(nuevaRuta);
            }

            // ACTA DE NACIMIENTO
            if (model.ActaNacimientoFile != null && model.ActaNacimientoFile.Length > 0)
            {
                var nombreCorto = Convert.ToBase64String(Guid.NewGuid().ToByteArray())
                    .Replace("=", "").Replace("+", "").Replace("/", "") // Quitar caracteres especiales
                    .Substring(0, 8);
                var nuevoNombre = $"acta_{userId}_{nombreCorto}{Path.GetExtension(model.ActaNacimientoFile.FileName)}";
                var nuevaRuta = Path.Combine(rutaBase, nuevoNombre);

                if (!string.IsNullOrEmpty(model.UsuarioInformacion.ActaNacimientoUrl))
                {
                    var anteriorRuta = Path.Combine(rutaBase, Path.GetFileName(model.UsuarioInformacion.ActaNacimientoUrl));
                    if (System.IO.File.Exists(anteriorRuta))
                        archivosAnteriores.Add(anteriorRuta);
                }

                using (var stream = new FileStream(nuevaRuta, FileMode.Create))
                    await model.ActaNacimientoFile.CopyToAsync(stream);

                model.UsuarioInformacion.ActaNacimientoUrl = $"/archivosPrivados/Empleados/Documentos/{nuevoNombre}";
                archivosGuardados.Add(nuevaRuta);
            }

            // COMPROBANTE DE DOMICILIO
            if (model.ComprobanteDom != null && model.ComprobanteDom.Length > 0)
            {
                var nombreCorto = Convert.ToBase64String(Guid.NewGuid().ToByteArray())
                    .Replace("=", "").Replace("+", "").Replace("/", "") // Quitar caracteres especiales
                    .Substring(0, 8);
                var nuevoNombre = $"comprobante_{userId}_{nombreCorto}{Path.GetExtension(model.ComprobanteDom.FileName)}";
                var nuevaRuta = Path.Combine(rutaBase, nuevoNombre);

                if (!string.IsNullOrEmpty(model.Direccion.ComprobanteDomicilioUrl))
                {
                    var anteriorRuta = Path.Combine(rutaBase, Path.GetFileName(model.Direccion.ComprobanteDomicilioUrl));
                    if (System.IO.File.Exists(anteriorRuta))
                        archivosAnteriores.Add(anteriorRuta);
                }

                using (var stream = new FileStream(nuevaRuta, FileMode.Create))
                    await model.ComprobanteDom.CopyToAsync(stream);

                model.Direccion.ComprobanteDomicilioUrl = $"/archivosPrivados/Empleados/Documentos/{nuevoNombre}";
                archivosGuardados.Add(nuevaRuta);
            }
        }

        private async Task ActualizarUsuarioInformacion(ContenedorViewModel model)
        {
            var usuarioExistente = await _context.UsuarioInformacions
                .FirstOrDefaultAsync(x => x.IdUsuarioLogin == model.UsuarioInformacion.IdUsuarioLogin);

            if (usuarioExistente != null)
            {
                usuarioExistente.IdPronombre = model.UsuarioInformacion.IdPronombre;
                usuarioExistente.IdEstadoCivil = model.UsuarioInformacion.IdEstadoCivil;
                usuarioExistente.IdPais = model.UsuarioInformacion.IdPais;
                usuarioExistente.NumeroColaborador = model.UsuarioInformacion.NumeroColaborador;
                usuarioExistente.FechaNacimiento = model.UsuarioInformacion.FechaNacimiento;
                usuarioExistente.Telefono = model.UsuarioInformacion.Telefono;
                usuarioExistente.IdTallaPlayera = model.UsuarioInformacion.IdTallaPlayera;
                usuarioExistente.IdNivelEstudio = model.UsuarioInformacion.IdNivelEstudio;
                usuarioExistente.CedulaProfesional = model.UsuarioInformacion.CedulaProfesional;
                usuarioExistente.CurriculumVitaeUrl =
                    !string.IsNullOrEmpty(model.UsuarioInformacion.CurriculumVitaeUrl)
                    ? model.UsuarioInformacion.CurriculumVitaeUrl
                    : usuarioExistente.CurriculumVitaeUrl;
                usuarioExistente.ActaNacimientoUrl =
                    !string.IsNullOrEmpty(model.UsuarioInformacion.ActaNacimientoUrl)
                    ? model.UsuarioInformacion.ActaNacimientoUrl
                    : usuarioExistente.ActaNacimientoUrl;
                usuarioExistente.Banco = model.UsuarioInformacion.Banco;
                usuarioExistente.BancoClabe = model.UsuarioInformacion.BancoClabe;
                usuarioExistente.NumeroSeguroSocial = model.UsuarioInformacion.NumeroSeguroSocial;
                usuarioExistente.Rfc = model.UsuarioInformacion.Rfc;
                usuarioExistente.Curp = model.UsuarioInformacion.Curp;
                usuarioExistente.IdentificadorNacional = model.UsuarioInformacion.IdentificadorNacional;
                usuarioExistente.NumeroColaborador = model.UsuarioInformacion.NumeroColaborador;
                usuarioExistente.IdTipoContrato = model.UsuarioInformacion.IdTipoContrato;
                usuarioExistente.Puesto = model.UsuarioInformacion.Puesto;
                usuarioExistente.IdEmpresa = model.UsuarioInformacion.IdEmpresa;
                usuarioExistente.IdDepartamento = model.UsuarioInformacion.IdDepartamento;
                usuarioExistente.IdSupervisor = model.UsuarioInformacion.IdSupervisor;
                usuarioExistente.IdSupervisor = model.UsuarioInformacion.IdSupervisor;
                usuarioExistente.FechaIngreso = model.UsuarioInformacion.FechaIngreso;
                usuarioExistente.FechaIngresoAsalariado = model.UsuarioInformacion.FechaIngresoAsalariado;
                usuarioExistente.FechaFinContrato = model.UsuarioInformacion.FechaFinContrato;
                usuarioExistente.DuracionJornada = model.UsuarioInformacion.DuracionJornada;
                usuarioExistente.Sueldo = model.UsuarioInformacion.Sueldo;
                usuarioExistente.SueldoDivisa = model.UsuarioInformacion.SueldoDivisa;
                usuarioExistente.Notas = model.UsuarioInformacion.Notas;

                _context.Update(usuarioExistente);
            }
        }

        private async Task ActualizarDireccion(ContenedorViewModel model)
        {
            try
            {
                var direccionExistente = await _context.Direccions
                    .FirstOrDefaultAsync(x => x.IdUsuario == model.UsuarioInformacion.IdUsuarioLogin);

                if (direccionExistente != null)
                {
                    direccionExistente.Direccion_ = model.Direccion.Direccion_;
                    direccionExistente.Longitud = model.Direccion.Longitud;
                    direccionExistente.Latitud = model.Direccion.Latitud;
                    direccionExistente.GoogleMapsUrl = model.Direccion.GoogleMapsUrl;
                    direccionExistente.ComprobanteDomicilioUrl =
                        !string.IsNullOrEmpty(model.Direccion.ComprobanteDomicilioUrl)
                          ? model.Direccion.ComprobanteDomicilioUrl
                          : direccionExistente.ComprobanteDomicilioUrl;

                    _context.Update(direccionExistente);
                }
                else
                {
                    model.Direccion.IdUsuario = model.UsuarioInformacion.IdUsuarioLogin;
                    _context.Direccions.Add(model.Direccion);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }

        private async Task ActualizarCapacitaciones(ContenedorViewModel model)
        {
            try
            {
                var userId = model.UsuarioInformacion.IdUsuarioLogin;
                var capacitacionesExistentes = await _context.CapacitacionUsuarios
                    .Where(x => x.IdUsuario == userId)
                    .ToListAsync();

                // Agregar nuevas capacitaciones si no existen
                foreach (var nueva in model.CapacitacionVM)
                {
                    var existente = capacitacionesExistentes
                        .FirstOrDefault(e => e.IdCapacitacionTipo == nueva.IdCapacitacionTipo && e.Nombre == nueva.Nombre);

                    if (existente == null)
                    {
                        _context.CapacitacionUsuarios.Add(new CapacitacionUsuario
                        {
                            IdCapacitacionTipo = nueva.IdCapacitacionTipo,
                            Nombre = nueva.Nombre,
                            IdUsuario = userId
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar capacitaciones: {ex.Message}");
            }
        }

        private async Task ActualizarBeneficios(ContenedorViewModel model)
        {
            var userId = model.UsuarioInformacion.IdUsuarioLogin;
            var beneficiosExistentes = await _context.BeneficioUsuarios
                .Where(x => x.IdUsuarioInformacion == userId)
                .ToListAsync();

            var beneficiosSeleccionados = model.Beneficio.BeneficiosSeleccionados ?? new List<int>();

            // Eliminar los que ya no están seleccionados
            var beneficiosAEliminar = beneficiosExistentes
                .Where(b => !beneficiosSeleccionados.Contains(b.IdBeneficio))
                .ToList();

            _context.BeneficioUsuarios.RemoveRange(beneficiosAEliminar);

            // Agregar los nuevos
            foreach (var idBeneficio in beneficiosSeleccionados)
            {
                if (!beneficiosExistentes.Any(b => b.IdBeneficio == idBeneficio))
                {
                    _context.BeneficioUsuarios.Add(new BeneficioUsuario
                    {
                        IdUsuarioInformacion = userId,
                        IdBeneficio = idBeneficio,
                        EstaAsignado = true
                    });
                }
            }
        }

        private bool UsuarioExists(int id)
        {
            return _context.UsuarioInformacions.Any(e => e.IdUsuarioLogin == id);
        }
    }
}
