using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Sperientia___SGI.Models;
using Sperientia___SGI.Models.dbModels.DbContext;
using System.Security.Claims;

namespace Sperientia___SGI.Filtros
{
    public class Validacion : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.User;
            var claim = user?.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null || !int.TryParse(claim.Value, out int currentUserId))
            {
                context.Result = new RedirectToActionResult("Login", "Cuenta", null);
                return;
            }

            using (var db = new SperientiaContext())
            {
                bool tieneParametros = db.UsuarioInformacions.Any(p => p.IdUsuarioLogin == currentUserId);

                if (!tieneParametros)
                {
                    context.Result = new RedirectToActionResult("AccesoDenegado", "Error", null);
                    return;
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
