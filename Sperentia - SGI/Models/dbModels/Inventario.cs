namespace Sperientia___SGI.Models.dbModels
{
    // Inventario
    public class Inventario
    {
        public int IdInventario { get; set; } // IdInventario (Primary key)
        public string CodigoInterno { get; set; } // CodigoInterno (length: 50)
        public string Foto { get; set; } // Foto (length: 500)
        public string Nombre { get; set; } // Nombre (length: 100)
        public string Descripcion { get; set; } // Descripcion (length: 500)
        public int IdCategoria { get; set; } // IdCategoria
        public DateTime? FechaCompra { get; set; } // FechaCompra
        public decimal? Costo { get; set; } // Costo
        public string Proveedor { get; set; } // Proveedor (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child InventarioAsignacions where [InventarioAsignacion].[IdInventario] point to this entity (FK_InventarioAsignacion_Inventario)
        /// </summary>
        public ICollection<InventarioAsignacion> InventarioAsignacions { get; set; } // InventarioAsignacion.FK_InventarioAsignacion_Inventario

        /// <summary>
        /// Parent (One-to-One) Inventario pointed by [InventarioGeneral].[IdInventario] (FK_InventarioGeneral_Inventario)
        /// </summary>
        public InventarioGeneral InventarioGeneral { get; set; } // InventarioGeneral.FK_InventarioGeneral_Inventario

        /// <summary>
        /// Parent (One-to-One) Inventario pointed by [InventarioLibro].[IdInventario] (FK_InventarioLibro_Inventario)
        /// </summary>
        public InventarioLibro InventarioLibro { get; set; } // InventarioLibro.FK_InventarioLibro_Inventario

        // Foreign keys

        /// <summary>
        /// Parent InventarioCategoria pointed by [Inventario].([IdCategoria]) (FK_Inventario_Categoria)
        /// </summary>
        public InventarioCategoria InventarioCategoria { get; set; } // FK_Inventario_Categoria

        public Inventario()
        {
            InventarioAsignacions = new List<InventarioAsignacion>();
        }
    }
}
