using Microsoft.AspNetCore.Mvc.Rendering;
using Sperientia___SGI.Models.dbModels;

namespace Sperientia___SGI.ViewModel
{
    public class InventarioViewModel
    {
        public List<SelectListItem> InventarioCategoria { get; set; } = new();

        public Inventario Inventario { get; set; }
        public InventarioLibro Libro { get; set; }
        public InventarioGeneral General { get; set; }
        public InventarioAsignacion Asignar { get; set; }
        public List<SelectListItem> Usuarios { get; set; } = new();

        public List<SelectListItem> InventarioList { get; set; } = new();
        public List<InventarioAsignacion> InventarioUsr { get; set; }

        public IFormFile Fotografia { get; set; }
    }
}
