namespace Sperientia___SGI.Models.dbModels
{
    // Servicio
    public class Servicio
    {
        public int IdServicio { get; set; } // IdServicio (Primary key)
        public string Nombre { get; set; } // Nombre (length: 100)
        public decimal Costo { get; set; } // Costo
        public int CostoDivisa { get; set; } // CostoDivisa
        public string CostoFrecuencia { get; set; } // CostoFrecuencia (length: 50)
        public string MetodoPago { get; set; } // MetodoPago (length: 100)
        public DateTime? FechaAdquisicion { get; set; } // FechaAdquisicion
        public string CuentaRegistrada { get; set; } // CuentaRegistrada (length: 256)
        public string Contrasena { get; set; } // Contrasena (length: 50)
        public DateTime? UltimaModificacionContrasena { get; set; } // UltimaModificacionContrasena
        public string Url { get; set; } // URL (length: 500)
        public string Notas { get; set; } // Notas (length: 1000)

        // Reverse navigation

        /// <summary>
        /// Child ServicioUsuarios where [ServicioUsuario].[IdServicio] point to this entity (FK_ServicioUsuario_Servicio)
        /// </summary>
        public ICollection<ServicioUsuario> ServicioUsuarios { get; set; } // ServicioUsuario.FK_ServicioUsuario_Servicio

        // Foreign keys

        /// <summary>
        /// Parent Divisa pointed by [Servicio].([CostoDivisa]) (FK_Servicio_Divisa)
        /// </summary>
        public Divisa Divisa { get; set; } // FK_Servicio_Divisa

        public Servicio()
        {
            ServicioUsuarios = new List<ServicioUsuario>();
        }
    }
}
