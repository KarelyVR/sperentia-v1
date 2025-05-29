namespace Sperientia___SGI.Models.dbModels
{
    // ServicioUsuario
    public class ServicioUsuario
    {
        public int IdServicio { get; set; } // IdServicio (Primary key)
        public int IdUsuario { get; set; } // IdUsuario (Primary key)
        public DateTime FechaAsignacion { get; set; } // FechaAsignacion

        // Foreign keys

        /// <summary>
        /// Parent Servicio pointed by [ServicioUsuario].([IdServicio]) (FK_ServicioUsuario_Servicio)
        /// </summary>
        public Servicio Servicio { get; set; } // FK_ServicioUsuario_Servicio

        /// <summary>
        /// Parent UsuarioLogin pointed by [ServicioUsuario].([IdUsuario]) (FK_ServicioUsuario_Usuario)
        /// </summary>
        public ApplicationUser UsuarioLogin { get; set; } // FK_ServicioUsuario_Usuario
    }
}
