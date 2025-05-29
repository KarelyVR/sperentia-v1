namespace Sperientia___SGI.Models.dbModels
{
    // TallaPlayera
    public class TallaPlayera
    {
        public int IdTallaPlayera { get; set; } // IdTallaPlayera (Primary key)
        public string Talla { get; set; } // Talla (length: 10)

        // Reverse navigation

        /// <summary>
        /// Child UsuarioInformacions where [UsuarioInformacion].[IdTallaPlayera] point to this entity (FK_UsuarioInformacion_TallaPlayera)
        /// </summary>
        public ICollection<UsuarioInformacion> UsuarioInformacions { get; set; } // UsuarioInformacion.FK_UsuarioInformacion_TallaPlayera

        public TallaPlayera()
        {
            UsuarioInformacions = new List<UsuarioInformacion>();
        }
    }
}
