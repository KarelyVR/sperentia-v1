namespace Sperientia___SGI.Models.dbModels
{
    // Direccion
    public class Direccion
    {
        public int IdDireccion { get; set; } // IdDireccion (Primary key)
        public int IdUsuario { get; set; } // IdUsuario
        public string Direccion_ { get; set; } // Direccion (length: 500)
        public decimal? Latitud { get; set; } // Latitud
        public decimal? Longitud { get; set; } // Longitud
        public string GoogleMapsUrl { get; set; } // GoogleMapsUrl (length: 500)
        public string ComprobanteDomicilioUrl { get; set; } // ComprobanteDomicilioUrl (length: 500)

        // Foreign keys

        /// <summary>
        /// Parent UsuarioLogin pointed by [Direccion].([IdUsuario]) (FK_Direccion_Usuario)
        /// </summary>
        public ApplicationUser UsuarioLogin { get; set; } // FK_Direccion_Usuario
    }
}
