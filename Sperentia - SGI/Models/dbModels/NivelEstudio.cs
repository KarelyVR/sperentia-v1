namespace Sperientia___SGI.Models.dbModels
{
    // NivelEstudio
    public class NivelEstudio
    {
        public int IdNivelEstudio { get; set; } // IdNivelEstudio (Primary key)
        public string Descripcion { get; set; } // Descripcion (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child UsuarioInformacions where [UsuarioInformacion].[IdNivelEstudio] point to this entity (FK_UsuarioInformacion_NivelEstudio)
        /// </summary>
        public ICollection<UsuarioInformacion> UsuarioInformacions { get; set; } // UsuarioInformacion.FK_UsuarioInformacion_NivelEstudio

        public NivelEstudio()
        {
            UsuarioInformacions = new List<UsuarioInformacion>();
        }
    }
}
