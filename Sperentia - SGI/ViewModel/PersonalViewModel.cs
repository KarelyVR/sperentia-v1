using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sperientia___SGI.ViewModel
{
    public class PersonalViewModel
    {
        public List<SelectListItem> Usuarios { get; set; } = new();
       
        public List<SelectListItem> Pronombres { get; set; } = new();
       
        public List<SelectListItem> EstadoCivil { get; set; } = new();
        
        public List<SelectListItem> Pais { get; set; } = new();
        
        public List<SelectListItem> Playera { get; set; } = new();
       
        public List<SelectListItem> NivelEstudio { get; set; } = new();
        

    }
}
