namespace Sperientia___SGI.Models.dbModels
{
    // InventarioAsignacion
    public class InventarioAsignacion
    {
        public int IdInventario { get; set; } // IdInventario (Primary key)
        public int IdUsuario { get; set; } // IdUsuario (Primary key)
        public DateTime FechaEntrega { get; set; } // FechaEntrega
        public DateTime? FechaDevolucion { get; set; } // FechaDevolucion
        public string Nota { get; set; } // Nota (length: 500)

        // Foreign keys

        /// <summary>
        /// Parent Inventario pointed by [InventarioAsignacion].([IdInventario]) (FK_InventarioAsignacion_Inventario)
        /// </summary>
        public Inventario Inventario { get; set; } // FK_InventarioAsignacion_Inventario

        /// <summary>
        /// Parent UsuarioLogin pointed by [InventarioAsignacion].([IdUsuario]) (FK_InventarioAsignacion_Usuario)
        /// </summary>
        public ApplicationUser UsuarioLogin { get; set; } // FK_InventarioAsignacion_Usuario
    }
}
