using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sperientia___SGI.Models.dbModels.Configurations;

namespace Sperientia___SGI.Models.dbModels.DbContext
{
    public class SperientiaContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public SperientiaContext()
        {
        }

        public SperientiaContext(DbContextOptions<SperientiaContext> options)
            : base(options)
        {
        }

        public DbSet<Ausencia> Ausencias { get; set; } // Ausencia
        public DbSet<Beneficio> Beneficios { get; set; } // Beneficio
        public DbSet<BeneficioUsuario> BeneficioUsuarios { get; set; } // BeneficioUsuario
        public DbSet<CapacitacionTipo> CapacitacionTipoes { get; set; } // CapacitacionTipo
        public DbSet<CapacitacionUsuario> CapacitacionUsuarios { get; set; } // CapacitacionUsuario
        public DbSet<Departamento> Departamentoes { get; set; } // Departamento
        public DbSet<Direccion> Direccions { get; set; } // Direccion
        public DbSet<Divisa> Divisas { get; set; } // Divisa
        public DbSet<Empresa> Empresas { get; set; } // Empresa
        public DbSet<EstadoCivil> EstadoCivils { get; set; } // EstadoCivil
        public DbSet<Inventario> Inventarios { get; set; } // Inventario
        public DbSet<InventarioAsignacion> InventarioAsignacions { get; set; } // InventarioAsignacion
        public DbSet<InventarioCategoria> InventarioCategorias { get; set; } // InventarioCategoria
        public DbSet<InventarioGeneral> InventarioGenerals { get; set; } // InventarioGeneral
        public DbSet<InventarioLibro> InventarioLibroes { get; set; } // InventarioLibro
        public DbSet<NivelEstudio> NivelEstudios { get; set; } // NivelEstudio
        public DbSet<Pais> Pais { get; set; } // Pais
        public DbSet<Pronombre> Pronombres { get; set; } // Pronombre
        public DbSet<Servicio> Servicios { get; set; } // Servicio
        public DbSet<ServicioUsuario> ServicioUsuarios { get; set; } // ServicioUsuario
        public DbSet<SolicitudVacaciones> SolicitudVacaciones { get; set; } // SolicitudVacaciones
        public DbSet<SolicitudVacacionesDia> SolicitudVacacionesDias { get; set; } // SolicitudVacacionesDias
        public DbSet<SolicitudVacacionesEstatus> SolicitudVacacionesEstatus { get; set; } // SolicitudVacacionesEstatus
        public DbSet<TallaPlayera> TallaPlayeras { get; set; } // TallaPlayera
        public DbSet<TipoContrato> TipoContratoes { get; set; } // TipoContrato
        public DbSet<UsuarioInformacion> UsuarioInformacions { get; set; } // UsuarioInformacion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AusenciaConfiguration());
            modelBuilder.ApplyConfiguration(new BeneficioConfiguration());
            modelBuilder.ApplyConfiguration(new BeneficioUsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new CapacitacionTipoConfiguration());
            modelBuilder.ApplyConfiguration(new CapacitacionUsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new DepartamentoConfiguration());
            modelBuilder.ApplyConfiguration(new DireccionConfiguration());
            modelBuilder.ApplyConfiguration(new DivisaConfiguration());
            modelBuilder.ApplyConfiguration(new EmpresaConfiguration());
            modelBuilder.ApplyConfiguration(new EstadoCivilConfiguration());
            modelBuilder.ApplyConfiguration(new InventarioConfiguration());
            modelBuilder.ApplyConfiguration(new InventarioAsignacionConfiguration());
            modelBuilder.ApplyConfiguration(new InventarioCategoriaConfiguration());
            modelBuilder.ApplyConfiguration(new InventarioGeneralConfiguration());
            modelBuilder.ApplyConfiguration(new InventarioLibroConfiguration());
            modelBuilder.ApplyConfiguration(new NivelEstudioConfiguration());
            modelBuilder.ApplyConfiguration(new PaisConfiguration());
            modelBuilder.ApplyConfiguration(new PronombreConfiguration());
            modelBuilder.ApplyConfiguration(new ServicioConfiguration());
            modelBuilder.ApplyConfiguration(new ServicioUsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new SolicitudVacacioneConfiguration());
            modelBuilder.ApplyConfiguration(new SolicitudVacacionesDiaConfiguration());
            modelBuilder.ApplyConfiguration(new SolicitudVacacionesEstatuConfiguration());
            modelBuilder.ApplyConfiguration(new TallaPlayeraConfiguration());
            modelBuilder.ApplyConfiguration(new TipoContratoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioInformacionConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioLoginConfiguration());
        }
    }
}
