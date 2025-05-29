using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Sperientia___SGI.ViewModel
{
    public class BeneficioViewModel
    {
        public List<SelectListItem> Beneficios { get; set; } = new();
        public List<int> BeneficiosSeleccionados { get; set; } = new();
        public List<SelectListItem> BeneficiosDisponibles { get; set; } = new(); 
    }
}
