namespace Sperientia___SGI.Models.dbModels
{
    // Ausencia
    public class Ausencia
    {
        public int IdAusencia { get; set; } // IdAusencia (Primary key)
        public int IdUsuario { get; set; } // IdUsuario
        public DateTime FechaInicio { get; set; } // FechaInicio
        public DateTime? FechaFin { get; set; } // FechaFin
        public string MotivoAusencia { get; set; } // MotivoAusencia (length: 500)

        // Foreign keys

        /// <summary>
        /// Parent UsuarioLogin pointed by [Ausencia].([IdUsuario]) (FK_Ausencia_Usuario)
        /// </summary>
        public ApplicationUser UsuarioLogin { get; set; } // FK_Ausencia_Usuario
    }
}
