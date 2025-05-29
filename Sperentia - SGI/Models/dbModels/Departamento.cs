namespace Sperientia___SGI.Models.dbModels
{
    // Departamento
    public class Departamento
    {
        public int IdDepartamento { get; set; } // IdDepartamento (Primary key)
        public string Nombre { get; set; } // Nombre (length: 100)

        // Reverse navigation

        /// <summary>
        /// Child UsuarioInformacions where [UsuarioInformacion].[IdDepartamento] point to this entity (FK_UsuarioInformacion_Departamento)
        /// </summary>
        public ICollection<UsuarioInformacion> UsuarioInformacions { get; set; } // UsuarioInformacion.FK_UsuarioInformacion_Departamento

        public Departamento()
        {
            UsuarioInformacions = new List<UsuarioInformacion>();
        }
    }
}
