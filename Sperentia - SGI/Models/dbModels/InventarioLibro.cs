namespace Sperientia___SGI.Models.dbModels
{
    // InventarioLibro
    public class InventarioLibro
    {
        public int IdInventario { get; set; } // IdInventario (Primary key)
        public string Autor { get; set; } // Autor (length: 100)
        public string Reseña { get; set; } // Reseña (length: 500)
        public string Editorial { get; set; } // Editorial (length: 100)
        public string Isbn { get; set; } // ISBN (length: 20)
        public bool EsDigital { get; set; } // EsDigital

        // Foreign keys

        /// <summary>
        /// Parent Inventario pointed by [InventarioLibro].([IdInventario]) (FK_InventarioLibro_Inventario)
        /// </summary>
        public Inventario Inventario { get; set; } // FK_InventarioLibro_Inventario
    }
}
