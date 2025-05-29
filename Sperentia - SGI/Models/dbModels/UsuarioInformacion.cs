namespace Sperientia___SGI.Models.dbModels
{
    // UsuarioInformacion
    public class UsuarioInformacion
    {
        public int IdUsuarioLogin { get; set; } // IdUsuarioLogin (Primary key)
        public int? IdPronombre { get; set; } // IdPronombre
        public int IdEstadoCivil { get; set; } // IdEstadoCivil
        public int IdPais { get; set; } // IdPais
        public DateTime FechaNacimiento { get; set; } // FechaNacimiento
        public string Telefono { get; set; } // Telefono (length: 20)
        public int? IdTallaPlayera { get; set; } // IdTallaPlayera
        public int IdNivelEstudio { get; set; } // IdNivelEstudio
        public string CedulaProfesional { get; set; } // CedulaProfesional (length: 50)
        public string CurriculumVitaeUrl { get; set; } // CurriculumVitaeUrl (length: 500)
        public string ActaNacimientoUrl { get; set; } // ActaNacimientoUrl (length: 500)
        public string Banco { get; set; } // Banco (length: 50)
        public string BancoClabe { get; set; } // BancoCLABE (length: 50)
        public string NumeroSeguroSocial { get; set; } // NumeroSeguroSocial (length: 50)
        public string Rfc { get; set; } // RFC (length: 50)
        public string Curp { get; set; } // CURP (length: 50)
        public string IdentificadorNacional { get; set; } // IdentificadorNacional (length: 50)
        public string NumeroColaborador { get; set; } // NumeroColaborador (length: 50)
        public int IdTipoContrato { get; set; } // IdTipoContrato
        public string Puesto { get; set; } // Puesto (length: 50)
        public int IdEmpresa { get; set; } // IdEmpresa
        public int IdDepartamento { get; set; } // IdDepartamento
        public int? IdSupervisor { get; set; } // IdSupervisor
        public DateTime FechaIngreso { get; set; } // FechaIngreso
        public DateTime? FechaIngresoAsalariado { get; set; } // FechaIngresoAsalariado
        public DateTime? FechaFinContrato { get; set; } // FechaFinContrato
        public int? DuracionJornada { get; set; } // DuracionJornada
        public int Sueldo { get; set; } // Sueldo
        public int SueldoDivisa { get; set; } // SueldoDivisa
        public string Notas { get; set; } // Notas
        public int DiasDisponiblesVacaciones { get; set; } // DiasDisponiblesVacaciones

        // Foreign keys

        /// <summary>
        /// Parent Departamento pointed by [UsuarioInformacion].([IdDepartamento]) (FK_UsuarioInformacion_Departamento)
        /// </summary>
        public Departamento Departamento { get; set; } // FK_UsuarioInformacion_Departamento

        /// <summary>
        /// Parent Divisa pointed by [UsuarioInformacion].([SueldoDivisa]) (FK_UsuarioInformacion_Divisa)
        /// </summary>
        public Divisa Divisa { get; set; } // FK_UsuarioInformacion_Divisa

        /// <summary>
        /// Parent Empresa pointed by [UsuarioInformacion].([IdEmpresa]) (FK_UsuarioInformacion_Empresa)
        /// </summary>
        public Empresa Empresa { get; set; } // FK_UsuarioInformacion_Empresa

        /// <summary>
        /// Parent EstadoCivil pointed by [UsuarioInformacion].([IdEstadoCivil]) (FK_UsuarioInformacion_EstadoCivil)
        /// </summary>
        public EstadoCivil EstadoCivil { get; set; } // FK_UsuarioInformacion_EstadoCivil

        /// <summary>
        /// Parent NivelEstudio pointed by [UsuarioInformacion].([IdNivelEstudio]) (FK_UsuarioInformacion_NivelEstudio)
        /// </summary>
        public NivelEstudio NivelEstudio { get; set; } // FK_UsuarioInformacion_NivelEstudio

        /// <summary>
        /// Parent Pai pointed by [UsuarioInformacion].([IdPais]) (FK_UsuarioInformacion_Pais)
        /// </summary>
        public Pais Pai { get; set; } // FK_UsuarioInformacion_Pais

        /// <summary>
        /// Parent Pronombre pointed by [UsuarioInformacion].([IdPronombre]) (FK_UsuarioInformacion_Pronombre)
        /// </summary>
        public Pronombre Pronombre { get; set; } // FK_UsuarioInformacion_Pronombre

        /// <summary>
        /// Parent TallaPlayera pointed by [UsuarioInformacion].([IdTallaPlayera]) (FK_UsuarioInformacion_TallaPlayera)
        /// </summary>
        public TallaPlayera TallaPlayera { get; set; } // FK_UsuarioInformacion_TallaPlayera

        /// <summary>
        /// Parent TipoContrato pointed by [UsuarioInformacion].([IdTipoContrato]) (FK_UsuarioInformacion_TipoContrato)
        /// </summary>
        public TipoContrato TipoContrato { get; set; } // FK_UsuarioInformacion_TipoContrato

        /// <summary>
        /// Parent UsuarioLogin pointed by [UsuarioInformacion].([IdSupervisor]) (FK_UsuarioInformacion_Supervisor)
        /// </summary>
        public ApplicationUser UsuarioLogin_IdSupervisor { get; set; } // FK_UsuarioInformacion_Supervisor

        /// <summary>
        /// Parent UsuarioLogin pointed by [UsuarioInformacion].([IdUsuarioLogin]) (FK_UsuarioInformacion_UsuarioLogin)
        /// </summary>
        public ApplicationUser UsuarioLogin_IdUsuarioLogin { get; set; } // FK_UsuarioInformacion_UsuarioLogin

        public UsuarioInformacion()
        {
            DiasDisponiblesVacaciones = 12;
        }
    }
}
