using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Sperientia___SGI.Models.dbModels;
using Sperientia___SGI.Models.dbModels.DbContext;
using System.Security.Claims;

namespace Sperientia___SGI.Models.Services
{
    public class UserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly SperientiaContext _context;
        private readonly IMemoryCache _cache;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, SperientiaContext context, IMemoryCache cache)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _cache = cache;
        }

        /// <summary>
        /// Obtiene si el usuario pertenece a un rol específico.
        /// </summary>
        public async Task<bool> IsInRoleAsync(ClaimsPrincipal userPrincipal, string role)
        {
            var user = await _userManager.GetUserAsync(userPrincipal);
            return user != null && await _userManager.IsInRoleAsync(user, role);
        }

        /// <summary>
        /// Obtiene el id de usuario.
        /// </summary>
        public async Task<int> GetIdAsync(ClaimsPrincipal userPrincipal)
        {
            var user = await _userManager.GetUserAsync(userPrincipal);
            return user?.Id ?? 0;
        }

        /// <summary>
        /// Obtiene el nombre completo del usuario.
        /// </summary>
        public async Task<string> GetFullNameAsync(ClaimsPrincipal userPrincipal)
        {
            var user = await _userManager.GetUserAsync(userPrincipal);
            return user != null ? $"{user.NombreCompleto}" : "Usuario";
        }

        /// <summary>
        /// Obtiene el nombre de usuario.
        /// </summary>
        public async Task<string> GetUserNameAsync(ClaimsPrincipal userPrincipal)
        {
            var user = await _userManager.GetUserAsync(userPrincipal);
            return user != null ? user?.UserName ?? "Usuario" : "Anónimo";
        }

        /// <summary>
        /// Obtiene la foto de perfil del usuario.
        /// </summary>
        /*
        public async Task<string> GetProfilePictureAsync(ClaimsPrincipal userPrincipal)
        {
            var userId = _userManager.GetUserId(userPrincipal);
            if (string.IsNullOrEmpty(userId))
            {
                return "/img/PerfilDefault.jpg"; // Imagen por defecto
            }

            // Verificar caché
            if (_cache.TryGetValue($"UserProfilePic_{userId}", out string cachedUrl))
            {
                return cachedUrl;
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            if (user == null)
            {
                return "/img/PerfilDefault.jpg"; // Imagen por defecto
            }

            string profileUrl;

            if (user.FotografiaUrl != null)
            {
                profileUrl = user.FotografiaUrl;
            }
            else
            {
                profileUrl = "/img/PerfilDefault.jpg";
            }

            // Guardar en caché
            _cache.Set($"UserProfilePic_{userId}", profileUrl, TimeSpan.FromMinutes(10));

            return profileUrl;
        }

        public void RemoveUserProfileCache(string userId)
        {
            var cacheKey = $"UserProfilePic_{userId}";
            _cache.Remove(cacheKey); // Elimina la caché correctamente
        }
        */

        /// <summary>
        /// Verifica si el usuario está autenticado.
        /// </summary>
        public bool IsSignedIn(ClaimsPrincipal user)
        {
            return _signInManager.IsSignedIn(user);
        }
    }
}
