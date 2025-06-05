using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Sperientia___SGI.Models.dbModels;

namespace Sperientia___SGI.Filtros
{
    public class ValidarAdmin : IAsyncActionFilter
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ValidarAdmin(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var user = context.HttpContext.User;
            var usuarioActual = await _userManager.GetUserAsync(user);

            if (usuarioActual == null || !await _userManager.IsInRoleAsync(usuarioActual, "Administrador"))
            {
                context.Result = new RedirectToActionResult("Error", "Home", null);
                return;
            }

            await next();
        }
    }

}
