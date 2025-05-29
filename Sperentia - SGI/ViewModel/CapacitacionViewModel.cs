using Microsoft.AspNetCore.Mvc.Rendering;
using Sperientia___SGI.Models.dbModels;

namespace Sperientia___SGI.ViewModel
{
    public class CapacitacionViewModel
    {
        public List<SelectListItem> TipoCapacitacion { get; set; } = new();
        public int capacitacionId { get; set; }
        public List<CapacitacionTipo> Capacitaciones { get; set; } = new();
        public int IdCapacitacionUsuario { get; set; }
        public int IdCapacitacionTipo { get; set; }
        public string Nombre { get; set; }
        public CapacitacionTipo CapacitacionTipo { get; set; }
    }
}
