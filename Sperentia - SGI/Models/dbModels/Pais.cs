namespace Sperientia___SGI.Models.dbModels
{
    // Pais
    public class Pais
    {
        public int IdPais { get; set; } // IdPais (Primary key)
        public string Nombre { get; set; } // Nombre (length: 100)

        // Reverse navigation

        /// <summary>
        /// Child UsuarioInformacions where [UsuarioInformacion].[IdPais] point to this entity (FK_UsuarioInformacion_Pais)
        /// </summary>
        public ICollection<UsuarioInformacion> UsuarioInformacions { get; set; } // UsuarioInformacion.FK_UsuarioInformacion_Pais

        public Pais()
        {
            UsuarioInformacions = new List<UsuarioInformacion>();
        }
    }
}
