using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sperientia___SGI.Models.dbModels;
using Sperientia___SGI.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Sperientia___SGI.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole<int>> roleManager,
            ILogger<UsuarioController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var listaUsuarios = await _userManager.Users.ToListAsync();

            var model = new UsuarioViewModel
            {
                Usuarios = listaUsuarios
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            ModelState.Clear();
            var model = new UsuarioViewModel
            {
                Roles = (await _roleManager.Roles.ToListAsync())
                    .Select(r => new SelectListItem
                    {
                        Value = r.Name,
                        Text = r.Name
                    }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                var rutaBase = Path.Combine(Directory.GetCurrentDirectory(), "ArchivosPrivados/Empleados/FotosPerfil");

                try
                {
                    var baseD = Directory.GetCurrentDirectory();

                    if (!Directory.Exists(rutaBase))
                        Directory.CreateDirectory(rutaBase);

                    // Guardar foto
                    if (model.Fotografia != null && model.Fotografia.Length > 0)
                    {
                        var guid = Guid.NewGuid().ToString("N").Substring(0, 6);
                        var nombreArchivo = $"{guid}_{model.UserName}";
                        var rutaCompleta = Path.Combine(rutaBase, nombreArchivo);

                        using (var stream = new FileStream(rutaCompleta, FileMode.Create))
                        {
                            await model.Fotografia.CopyToAsync(stream);
                        }

                        model.FotografiaUrl = $"{nombreArchivo}";
                    }

                    var user = new ApplicationUser
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        NombreCompleto = model.NombreCompleto,
                        FotografiaUrl = model.FotografiaUrl,
                        EstaActivo = model.EstaActivo,
                        EmailConfirmed = true
                    };

                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation("Usuario creado exitosamente.");

                        // Asignar rol si se seleccionó uno
                        if (!string.IsNullOrEmpty(model.SelectedRole))
                        {
                            await _userManager.AddToRoleAsync(user, model.SelectedRole);
                        }

                        return RedirectToAction("Index", "Home");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");

                }
            }

            // Si llegamos aquí, algo falló, recargar roles
            model.Roles = (await _roleManager.Roles.ToListAsync())
                .Select(r => new SelectListItem
                {
                    Value = r.Name,
                    Text = r.Name
                }).ToList();

            return View(model);
        }

        public async Task<IActionResult> Modificar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _userManager.Users.FirstOrDefaultAsync(m => m.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            var viewModel = new UsuarioViewModel
            {
                NetUser = usuario
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ModificarRegistro(UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userExiste = await _userManager.Users.FirstOrDefaultAsync(m => m.Id == model.NetUser.Id);

            if (userExiste == null)
                return NotFound();

            try
            {
                // Actualizar campos
                userExiste.UserName = model.NetUser.UserName;
                userExiste.Email = model.NetUser.Email;
                userExiste.NombreCompleto = model.NetUser.NombreCompleto;
                userExiste.EstaActivo = model.NetUser.EstaActivo;

                // Actualizar foto si se carga una nueva
                if (model.Fotografia != null && model.Fotografia.Length > 0)
                {
                    var rutaBase = Path.Combine(Directory.GetCurrentDirectory(), "ArchivosPrivados/Empleados/FotosPerfil");

                    if (!Directory.Exists(rutaBase))
                        Directory.CreateDirectory(rutaBase);

                    var guid = Guid.NewGuid().ToString("N").Substring(0, 6);
                    var nombreArchivo = $"{guid}_{model.NetUser.UserName}";
                    var rutaCompleta = Path.Combine(rutaBase, nombreArchivo);

                    if (System.IO.File.Exists(userExiste.FotografiaUrl))
                        System.IO.File.Delete(userExiste.FotografiaUrl);

                    using (var stream = new FileStream(rutaCompleta, FileMode.Create))
                    {
                        await model.Fotografia.CopyToAsync(stream);
                    }

                    userExiste.FotografiaUrl = nombreArchivo;
                }

                // Actualizar datos en base de datos
                var result = await _userManager.UpdateAsync(userExiste);

                if (!string.IsNullOrEmpty(model.SelectedRole))
                {
                    var rolesActuales = await _userManager.GetRolesAsync(userExiste);
                    await _userManager.RemoveFromRolesAsync(userExiste, rolesActuales);
                    await _userManager.AddToRoleAsync(userExiste, model.SelectedRole);
                }

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ocurrió un error al actualizar el usuario: {ex.Message}");
            }

            // Recargar roles si algo falla
            model.Roles = (await _roleManager.Roles.ToListAsync())
                .Select(r => new SelectListItem
                {
                    Value = r.Name,
                    Text = r.Name
                }).ToList();

            return View(model);
        }

    }
}
