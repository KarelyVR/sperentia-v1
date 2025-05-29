using Microsoft.AspNetCore.Mvc.Rendering;
using Sperientia___SGI.Models.dbModels;

namespace Sperientia___SGI.ViewModel
{
    public class AusenciaViewModel
    {
        public List<SelectListItem>? Usuario { get; set; }
        
        public Ausencia Ausencia { get; set; }

    }
}
