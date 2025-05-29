using System.ComponentModel.DataAnnotations;

namespace Sperientia___SGI.Models.dbModels
{
    // Divisa
    public class Divisa
    {
        [Display(Name = "ID")]
        public int IdDivisa { get; set; } // IdDivisa (Primary key)
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } // Nombre (length: 50)
        [Display(Name = "Codigo")]
        public string Codigo { get; set; } // Codigo (length: 10)

        public ICollection<Servicio> Servicios { get; set; } // Servicio.FK_Servicio_Divisa

        public ICollection<UsuarioInformacion> UsuarioInformacions { get; set; } // UsuarioInformacion.FK_UsuarioInformacion_Divisa

        public Divisa()
        {
            Servicios = new List<Servicio>();
            UsuarioInformacions = new List<UsuarioInformacion>();
        }
    }
}
