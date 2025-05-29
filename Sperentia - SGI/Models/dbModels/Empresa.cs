namespace Sperientia___SGI.Models.dbModels
{
    // Empresa
    public class Empresa
    {
        public int IdEmpresa { get; set; } // IdEmpresa (Primary key)
        public string Nombre { get; set; } // Nombre (length: 100)

        // Reverse navigation

        /// <summary>
        /// Child UsuarioInformacions where [UsuarioInformacion].[IdEmpresa] point to this entity (FK_UsuarioInformacion_Empresa)
        /// </summary>
        public ICollection<UsuarioInformacion> UsuarioInformacions { get; set; } // UsuarioInformacion.FK_UsuarioInformacion_Empresa

        public Empresa()
        {
            UsuarioInformacions = new List<UsuarioInformacion>();
        }
    }
}
