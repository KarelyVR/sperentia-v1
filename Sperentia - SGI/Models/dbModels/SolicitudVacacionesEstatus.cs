namespace Sperientia___SGI.Models.dbModels
{
    // SolicitudVacacionesEstatus
    public class SolicitudVacacionesEstatus
    {
        public int IdEstatus { get; set; } // IdEstatus (Primary key)
        public string Descripcion { get; set; } // Descripcion (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child SolicitudVacaciones where [SolicitudVacaciones].[IdEstatus] point to this entity (FK_SolicitudVacaciones_Estatus)
        /// </summary>
        public ICollection<SolicitudVacaciones> SolicitudVacaciones { get; set; } // SolicitudVacaciones.FK_SolicitudVacaciones_Estatus

        public SolicitudVacacionesEstatus()
        {
            SolicitudVacaciones = new List<SolicitudVacaciones>();
        }
    }
}
