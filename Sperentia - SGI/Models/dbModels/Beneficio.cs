
using System.ComponentModel.DataAnnotations;

namespace Sperientia___SGI.Models.dbModels
{
    // Beneficio
    public class Beneficio
    {
        [Display(Name = "ID")]
        public int IdBeneficio { get; set; } // IdBeneficio (Primary key)
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } // Nombre (length: 50)
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; } // Descripcion (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child BeneficioUsuarios where [BeneficioUsuario].[IdBeneficio] point to this entity (FK_BeneficioUsuario_Beneficio)
        /// </summary>
        public ICollection<BeneficioUsuario> BeneficioUsuarios { get; set; } // BeneficioUsuario.FK_BeneficioUsuario_Beneficio

        public Beneficio()
        {
            BeneficioUsuarios = new List<BeneficioUsuario>();
        }
    }
}
