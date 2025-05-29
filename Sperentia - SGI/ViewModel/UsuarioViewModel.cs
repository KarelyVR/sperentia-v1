using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sperientia___SGI.Models.dbModels;
using System.ComponentModel.DataAnnotations;

namespace Sperientia___SGI.ViewModel
{
    public class UsuarioViewModel
    {
       
            [Required(ErrorMessage = "El nombre de usuario es requerido")]
            [Display(Name = "Nombre de Usuario")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "El correo electrónico es requerido")]
            [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
            [Display(Name = "Correo Electrónico")]
            public string Email { get; set; }
      

            [Required(ErrorMessage = "El nombre completo es requerido")]
            [Display(Name = "Nombre Completo")]
            public string NombreCompleto { get; set; }

            [Display(Name = "Fotografía")]
            public string? FotografiaUrl { get; set; }

            [Display(Name = "Usuario Activo")]
            public bool EstaActivo { get; set; } = true;

            [Required(ErrorMessage = "La contraseña es requerida")]
            [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} y máximo {1} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar Contraseña")]
            [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
            public string ConfirmPassword { get; set; }

            [Display(Name = "Rol")]
            public string? SelectedRole { get; set; }

            public List<SelectListItem>? Roles { get; set; }
            public IFormFile Fotografia { get; set; }

        public List<ApplicationUser> Usuarios { get; set; }
        public ApplicationUser NetUser { get; set; }

    }
}
