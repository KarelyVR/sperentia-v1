using Microsoft.AspNetCore.Mvc.Rendering;
using Sperientia___SGI.Models.dbModels;

namespace Sperientia___SGI.ViewModel
{
    public class ServiciosViewModel
    {
        public List<SelectListItem> Usuarios { get; set; } = new();
        public List<SelectListItem> Servicios { get; set; } = new();
        public List<SelectListItem> Divisa { get; set; } = new();
        public Servicio Servicio { get; set; }
        public ServicioUsuario ServicioUsuario { get; set; }
        public List<Servicio> ServicioInfo { get; set; }
        public List<ServicioUsuario> ServicioInfoUsr { get; set; }
    }
}
