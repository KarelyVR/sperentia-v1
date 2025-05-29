using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sperientia___SGI.ViewModel
{
    public class EmpresarialViewModel
    {
        public List<SelectListItem> Empresa { get; set; } = new();
        public int empresaId { get; set; }
        public List<SelectListItem> Departamento { get; set; } = new();
        public int departamentoId { get; set; }
        public List<SelectListItem> Divisa { get; set; } = new();
        public int divisaId { get; set; }
        public List<SelectListItem> TipoContrato { get; set; } = new();
        public int tipoContratoId { get; set; }
        public List<SelectListItem> Supervisor { get; set; } = new();

    }
}
