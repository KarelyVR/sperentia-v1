namespace Sperientia___SGI.Models.dbModels
{
    // TipoContrato
    public class TipoContrato
    {
        public int IdTipoContrato { get; set; } // IdTipoContrato (Primary key)
        public string Descripcion { get; set; } // Descripcion (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child UsuarioInformacions where [UsuarioInformacion].[IdTipoContrato] point to this entity (FK_UsuarioInformacion_TipoContrato)
        /// </summary>
        public ICollection<UsuarioInformacion> UsuarioInformacions { get; set; } // UsuarioInformacion.FK_UsuarioInformacion_TipoContrato

        public TipoContrato()
        {
            UsuarioInformacions = new List<UsuarioInformacion>();
        }
    }
}
