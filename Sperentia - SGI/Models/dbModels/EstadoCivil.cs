namespace Sperientia___SGI.Models.dbModels
{
    // EstadoCivil
    public class EstadoCivil
    {
        public int IdEstadoCivil { get; set; } // IdEstadoCivil (Primary key)
        public string Descripcion { get; set; } // Descripcion (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child UsuarioInformacions where [UsuarioInformacion].[IdEstadoCivil] point to this entity (FK_UsuarioInformacion_EstadoCivil)
        /// </summary>
        public ICollection<UsuarioInformacion> UsuarioInformacions { get; set; } // UsuarioInformacion.FK_UsuarioInformacion_EstadoCivil

        public EstadoCivil()
        {
            UsuarioInformacions = new List<UsuarioInformacion>();
        }
    }
}
