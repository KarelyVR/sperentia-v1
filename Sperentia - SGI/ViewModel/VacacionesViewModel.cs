using Microsoft.AspNetCore.Mvc.Rendering;
using Sperientia___SGI.Models.dbModels;

namespace Sperientia___SGI.ViewModel
{
    public class VacacionesViewModel
    {
        public SolicitudVacaciones  Vacaciones { get; set; }
        public SolicitudVacaciones  VacacionSolicitud { get; set; }
        public List<SelectListItem> Usuarios { get; set; } = new();
        public int DiasDisponiblesVacaciones { get; set; }
        public List<SolicitudVacaciones> Solicitudes { get; set; }
        public List<SelectListItem> Estatus { get; set; } = new();


        public List<DateTime> Fechas { get; set; } = new();

    }
}
