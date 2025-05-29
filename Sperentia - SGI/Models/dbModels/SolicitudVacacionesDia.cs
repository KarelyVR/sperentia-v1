namespace Sperientia___SGI.Models.dbModels
{
    // SolicitudVacacionesDias
    public class SolicitudVacacionesDia
    {
        public int IdSolicitud { get; set; } // IdSolicitud (Primary key)
        public DateTime Fecha { get; set; } // Fecha (Primary key)

        // Foreign keys

        /// <summary>
        /// Parent SolicitudVacacione pointed by [SolicitudVacacionesDias].([IdSolicitud]) (FK_SolicitudVacacionesDias_Solicitud)
        /// </summary>
        public SolicitudVacaciones SolicitudVacacione { get; set; } // FK_SolicitudVacacionesDias_Solicitud
    }
}
