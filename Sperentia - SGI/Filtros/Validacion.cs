using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Sperientia___SGI.Models;
using Sperientia___SGI.Models.dbModels.DbContext;
using System.Security.Claims;
using Sperientia___SGI.Models.dbModels;
using Microsoft.AspNetCore.Hosting;

namespace Sperientia___SGI.Filtros
{
    public class Validacion : IAsyncActionFilter
    {
        private readonly SperientiaContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public Validacion(SperientiaContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var user = context.HttpContext.User;
            var claim = user.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null || !int.TryParse(claim.Value, out int currentUserId))
            {
                context.Result = new RedirectToActionResult("Index", "Admin", null);
                return;
            }

            bool tienePerfil = _context.UsuarioInformacions.Any(p => p.IdUsuarioLogin == currentUserId);

            if (!tienePerfil)
            {
                context.Result = new RedirectToActionResult("Index", "Admin", null);
                return;
            }

            await next();
        }
        public void OnActionExecuted(ActionExecutedContext context) { }

    }
}
