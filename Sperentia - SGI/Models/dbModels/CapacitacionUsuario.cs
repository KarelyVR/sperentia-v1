namespace Sperientia___SGI.Models.dbModels
{
    // CapacitacionUsuario
    public class CapacitacionUsuario
    {
        public int IdCapacitacion { get; set; } // IdCapacitacion (Primary key)
        public int IdUsuario { get; set; } // IdUsuario
        public int IdCapacitacionTipo { get; set; } // IdCapacitacionTipo
        public string Nombre { get; set; } // Nombre (length: 50)

        // Foreign keys

        /// <summary>
        /// Parent CapacitacionTipo pointed by [CapacitacionUsuario].([IdCapacitacionTipo]) (FK_CapacitacionUsuario_CapacitacionTipo)
        /// </summary>
        public CapacitacionTipo CapacitacionTipo { get; set; } // FK_CapacitacionUsuario_CapacitacionTipo

        /// <summary>
        /// Parent UsuarioLogin pointed by [CapacitacionUsuario].([IdUsuario]) (FK_CapacitacionUsuario_Usuario)
        /// </summary>
        public ApplicationUser UsuarioLogin { get; set; } // FK_CapacitacionUsuario_Usuario
    }
}
