namespace Sperientia___SGI.Models.dbModels
{
    // CapacitacionTipo
    public class CapacitacionTipo
    {
        public int IdCapacitacionTipo { get; set; } // IdCapacitacionTipo (Primary key)
        public string Descripcion { get; set; } // Descripcion (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child CapacitacionUsuarios where [CapacitacionUsuario].[IdCapacitacionTipo] point to this entity (FK_CapacitacionUsuario_CapacitacionTipo)
        /// </summary>
        public ICollection<CapacitacionUsuario> CapacitacionUsuarios { get; set; } // CapacitacionUsuario.FK_CapacitacionUsuario_CapacitacionTipo

        public CapacitacionTipo()
        {
            CapacitacionUsuarios = new List<CapacitacionUsuario>();
        }
    }
}
