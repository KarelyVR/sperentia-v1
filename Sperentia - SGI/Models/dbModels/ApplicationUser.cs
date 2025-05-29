using Microsoft.AspNetCore.Identity;

namespace Sperientia___SGI.Models.dbModels
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string NombreCompleto { get; set; } // NombreCompleto (length: 100)
        public string? FotografiaUrl { get; set; } // FotografiaUrl (length: 500)
        public bool EstaActivo { get; set; } // EstaActivo

        // Reverse navigation

        /// <summary>
        /// Child Ausencias where [Ausencia].[IdUsuario] point to this entity (FK_Ausencia_Usuario)
        /// </summary>
        public ICollection<Ausencia> Ausencias { get; set; } // Ausencia.FK_Ausencia_Usuario

        /// <summary>
        /// Child BeneficioUsuarios where [BeneficioUsuario].[IdUsuarioInformacion] point to this entity (FK_BeneficioUsuario_Usuario)
        /// </summary>
        public ICollection<BeneficioUsuario> BeneficioUsuarios { get; set; } // BeneficioUsuario.FK_BeneficioUsuario_Usuario

        /// <summary>
        /// Child CapacitacionUsuarios where [CapacitacionUsuario].[IdUsuario] point to this entity (FK_CapacitacionUsuario_Usuario)
        /// </summary>
        public ICollection<CapacitacionUsuario> CapacitacionUsuarios { get; set; } // CapacitacionUsuario.FK_CapacitacionUsuario_Usuario

        /// <summary>
        /// Child Direccions where [Direccion].[IdUsuario] point to this entity (FK_Direccion_Usuario)
        /// </summary>
        public ICollection<Direccion> Direccions { get; set; } // Direccion.FK_Direccion_Usuario

        /// <summary>
        /// Child InventarioAsignacions where [InventarioAsignacion].[IdUsuario] point to this entity (FK_InventarioAsignacion_Usuario)
        /// </summary>
        public ICollection<InventarioAsignacion> InventarioAsignacions { get; set; } // InventarioAsignacion.FK_InventarioAsignacion_Usuario

        /// <summary>
        /// Child ServicioUsuarios where [ServicioUsuario].[IdUsuario] point to this entity (FK_ServicioUsuario_Usuario)
        /// </summary>
        public ICollection<ServicioUsuario> ServicioUsuarios { get; set; } // ServicioUsuario.FK_ServicioUsuario_Usuario

        /// <summary>
        /// Child SolicitudVacaciones where [SolicitudVacaciones].[IdEmpleado] point to this entity (FK_SolicitudVacaciones_Empleado)
        /// </summary>
        public ICollection<SolicitudVacaciones> SolicitudVacaciones_IdEmpleado { get; set; } // SolicitudVacaciones.FK_SolicitudVacaciones_Empleado

        /// <summary>
        /// Child SolicitudVacaciones where [SolicitudVacaciones].[IdUsuarioRH] point to this entity (FK_SolicitudVacaciones_UsuarioRH)
        /// </summary>
        public ICollection<SolicitudVacaciones> SolicitudVacaciones_IdUsuarioRh { get; set; } // SolicitudVacaciones.FK_SolicitudVacaciones_UsuarioRH

        /// <summary>
        /// Child UsuarioInformacions where [UsuarioInformacion].[IdSupervisor] point to this entity (FK_UsuarioInformacion_Supervisor)
        /// </summary>
        public ICollection<UsuarioInformacion> UsuarioInformacions { get; set; } // UsuarioInformacion.FK_UsuarioInformacion_Supervisor

        /// <summary>
        /// Parent (One-to-One) UsuarioLogin pointed by [UsuarioInformacion].[IdUsuarioLogin] (FK_UsuarioInformacion_UsuarioLogin)
        /// </summary>
        public UsuarioInformacion UsuarioInformacion { get; set; } // UsuarioInformacion.FK_UsuarioInformacion_UsuarioLogin

        public ApplicationUser()
        {
            EstaActivo = true;
            Ausencias = new List<Ausencia>();
            BeneficioUsuarios = new List<BeneficioUsuario>();
            CapacitacionUsuarios = new List<CapacitacionUsuario>();
            Direccions = new List<Direccion>();
            InventarioAsignacions = new List<InventarioAsignacion>();
            ServicioUsuarios = new List<ServicioUsuario>();
            SolicitudVacaciones_IdEmpleado = new List<SolicitudVacaciones>();
            SolicitudVacaciones_IdUsuarioRh = new List<SolicitudVacaciones>();
            UsuarioInformacions = new List<UsuarioInformacion>();
        }
    }
}
