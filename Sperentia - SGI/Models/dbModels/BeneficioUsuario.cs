namespace Sperientia___SGI.Models.dbModels
{
    // BeneficioUsuario
    public class BeneficioUsuario
    {
        public int IdUsuarioInformacion { get; set; } // IdUsuarioInformacion (Primary key)
        public int IdBeneficio { get; set; } // IdBeneficio (Primary key)
        public bool EstaAsignado { get; set; } // EstaAsignado

        // Foreign keys

        /// <summary>
        /// Parent Beneficio pointed by [BeneficioUsuario].([IdBeneficio]) (FK_BeneficioUsuario_Beneficio)
        /// </summary>
        public Beneficio Beneficio { get; set; } // FK_BeneficioUsuario_Beneficio

        /// <summary>
        /// Parent UsuarioLogin pointed by [BeneficioUsuario].([IdUsuarioInformacion]) (FK_BeneficioUsuario_Usuario)
        /// </summary>
        public ApplicationUser UsuarioLogin { get; set; } // FK_BeneficioUsuario_Usuario

        public BeneficioUsuario()
        {
            EstaAsignado = false;
        }
    }
}
