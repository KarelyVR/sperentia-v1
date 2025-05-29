namespace Sperientia___SGI.Models.dbModels
{
    // InventarioGeneral
    public class InventarioGeneral
    {
        public int IdInventario { get; set; } // IdInventario (Primary key)
        public string Marca { get; set; } // Marca (length: 50)
        public string Modelo { get; set; } // Modelo (length: 50)
        public string NumeroSerie { get; set; } // NumeroSerie (length: 50)
        public string EstadoCondicion { get; set; } // EstadoCondicion (length: 50)
        public DateTime? GarantiaFechaFin { get; set; } // GarantiaFechaFin

        // Foreign keys

        /// <summary>
        /// Parent Inventario pointed by [InventarioGeneral].([IdInventario]) (FK_InventarioGeneral_Inventario)
        /// </summary>
        public Inventario Inventario { get; set; } // FK_InventarioGeneral_Inventario
    }
}
