namespace Sperientia___SGI.Models.dbModels
{
    // Pronombre
    public class Pronombre
    {
        public int IdPronombre { get; set; } // IdPronombre (Primary key)
        public string Descripcion { get; set; } // Descripcion (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child UsuarioInformacions where [UsuarioInformacion].[IdPronombre] point to this entity (FK_UsuarioInformacion_Pronombre)
        /// </summary>
        public ICollection<UsuarioInformacion> UsuarioInformacions { get; set; } // UsuarioInformacion.FK_UsuarioInformacion_Pronombre

        public Pronombre()
        {
            UsuarioInformacions = new List<UsuarioInformacion>();
        }
    }
}
