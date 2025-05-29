namespace Sperientia___SGI.Models.dbModels
{
    // InventarioCategoria
    public class InventarioCategoria
    {
        public int IdCategoria { get; set; } // IdCategoria (Primary key)
        public string Nombre { get; set; } // Nombre (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child Inventarios where [Inventario].[IdCategoria] point to this entity (FK_Inventario_Categoria)
        /// </summary>
        public ICollection<Inventario> Inventarios { get; set; } // Inventario.FK_Inventario_Categoria

        public InventarioCategoria()
        {
            Inventarios = new List<Inventario>();
        }
    }
}
