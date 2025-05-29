using Microsoft.AspNetCore.Mvc.Rendering;
using Sperientia___SGI.Models.dbModels;

namespace Sperientia___SGI.ViewModel
{
    public class ContenedorViewModel
    {
        public BeneficioViewModel Beneficio { get; set; }
        public CapacitacionViewModel Capacitacion{ get; set; }
        public PersonalViewModel Personal { get; set; }
        public EmpresarialViewModel Empresarial { get; set; }

        public UsuarioInformacion UsuarioInformacion { get; set; }
        public Direccion Direccion { get; set; }
        public List<BeneficioUsuario> Beneficios { get; set; }
        public List<CapacitacionUsuario> Capacitaciones { get; set; }
        public List<UsuarioInformacion> Empleados { get; set; }

        public IFormFile CurriculumFile { get; set; }
        public IFormFile ActaNacimientoFile { get; set; }
        public IFormFile ComprobanteDom { get; set; }

        public List<CapacitacionViewModel> CapacitacionVM { get; set; } = new();
    }
}
