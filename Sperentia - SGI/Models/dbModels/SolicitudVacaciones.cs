namespace Sperientia___SGI.Models.dbModels
{
    // SolicitudVacaciones
    public class SolicitudVacaciones
    {
        public int IdSolicitud { get; set; } // IdSolicitud (Primary key)
        public int IdEmpleado { get; set; } // IdEmpleado
        public DateTime FechaSolicitud { get; set; } // FechaSolicitud
        public int DerechoDiasEmpleado { get; set; } // DerechoDiasEmpleado
        public int? IdUsuarioRh { get; set; } // IdUsuarioRH
        public int IdEstatus { get; set; } // IdEstatus
        public string SustitutoNombre { get; set; } // SustitutoNombre (length: 100)
        public string SustitutoTelefono { get; set; } // SustitutoTelefono (length: 20)

        // Reverse navigation

        /// <summary>
        /// Child SolicitudVacacionesDias where [SolicitudVacacionesDias].[IdSolicitud] point to this entity (FK_SolicitudVacacionesDias_Solicitud)
        /// </summary>
        public ICollection<SolicitudVacacionesDia> SolicitudVacacionesDias { get; set; } // SolicitudVacacionesDias.FK_SolicitudVacacionesDias_Solicitud

        // Foreign keys

        /// <summary>
        /// Parent SolicitudVacacionesEstatu pointed by [SolicitudVacaciones].([IdEstatus]) (FK_SolicitudVacaciones_Estatus)
        /// </summary>
        public SolicitudVacacionesEstatus SolicitudVacacionesEstatu { get; set; } // FK_SolicitudVacaciones_Estatus

        /// <summary>
        /// Parent UsuarioLogin pointed by [SolicitudVacaciones].([IdEmpleado]) (FK_SolicitudVacaciones_Empleado)
        /// </summary>
        public ApplicationUser UsuarioLogin_IdEmpleado { get; set; } // FK_SolicitudVacaciones_Empleado

        /// <summary>
        /// Parent UsuarioLogin pointed by [SolicitudVacaciones].([IdUsuarioRh]) (FK_SolicitudVacaciones_UsuarioRH)
        /// </summary>
        public ApplicationUser UsuarioLogin_IdUsuarioRh { get; set; } // FK_SolicitudVacaciones_UsuarioRH

        public SolicitudVacaciones()
        {
            SolicitudVacacionesDias = new List<SolicitudVacacionesDia>();
        }
    }
}
