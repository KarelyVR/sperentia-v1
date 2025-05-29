using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // UsuarioInformacion
    public class UsuarioInformacionConfiguration : IEntityTypeConfiguration<UsuarioInformacion>
    {
        public void Configure(EntityTypeBuilder<UsuarioInformacion> builder)
        {
            builder.ToTable("UsuarioInformacion", "dbo");
            builder.HasKey(x => x.IdUsuarioLogin).HasName("PK__UsuarioI__9E973030AF5A6385").IsClustered();

            builder.Property(x => x.IdUsuarioLogin).HasColumnName(@"IdUsuarioLogin").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.IdPronombre).HasColumnName(@"IdPronombre").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.IdEstadoCivil).HasColumnName(@"IdEstadoCivil").HasColumnType("int").IsRequired();
            builder.Property(x => x.IdPais).HasColumnName(@"IdPais").HasColumnType("int").IsRequired();
            builder.Property(x => x.FechaNacimiento).HasColumnName(@"FechaNacimiento").HasColumnType("date").IsRequired();
            builder.Property(x => x.Telefono).HasColumnName(@"Telefono").HasColumnType("nvarchar(20)").IsRequired().HasMaxLength(20);
            builder.Property(x => x.IdTallaPlayera).HasColumnName(@"IdTallaPlayera").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.IdNivelEstudio).HasColumnName(@"IdNivelEstudio").HasColumnType("int").IsRequired();
            builder.Property(x => x.CedulaProfesional).HasColumnName(@"CedulaProfesional").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.CurriculumVitaeUrl).HasColumnName(@"CurriculumVitaeUrl").HasColumnType("nvarchar(500)").IsRequired().HasMaxLength(500);
            builder.Property(x => x.ActaNacimientoUrl).HasColumnName(@"ActaNacimientoUrl").HasColumnType("nvarchar(500)").IsRequired().HasMaxLength(500);
            builder.Property(x => x.Banco).HasColumnName(@"Banco").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.BancoClabe).HasColumnName(@"BancoCLABE").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.NumeroSeguroSocial).HasColumnName(@"NumeroSeguroSocial").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.Rfc).HasColumnName(@"RFC").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.Curp).HasColumnName(@"CURP").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.IdentificadorNacional).HasColumnName(@"IdentificadorNacional").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.NumeroColaborador).HasColumnName(@"NumeroColaborador").HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50);
            builder.Property(x => x.IdTipoContrato).HasColumnName(@"IdTipoContrato").HasColumnType("int").IsRequired();
            builder.Property(x => x.Puesto).HasColumnName(@"Puesto").HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50);
            builder.Property(x => x.IdEmpresa).HasColumnName(@"IdEmpresa").HasColumnType("int").IsRequired();
            builder.Property(x => x.IdDepartamento).HasColumnName(@"IdDepartamento").HasColumnType("int").IsRequired();
            builder.Property(x => x.IdSupervisor).HasColumnName(@"IdSupervisor").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.FechaIngreso).HasColumnName(@"FechaIngreso").HasColumnType("date").IsRequired();
            builder.Property(x => x.FechaIngresoAsalariado).HasColumnName(@"FechaIngresoAsalariado").HasColumnType("date").IsRequired(false);
            builder.Property(x => x.FechaFinContrato).HasColumnName(@"FechaFinContrato").HasColumnType("date").IsRequired(false);
            builder.Property(x => x.DuracionJornada).HasColumnName(@"DuracionJornada").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Sueldo).HasColumnName(@"Sueldo").HasColumnType("int").IsRequired();
            builder.Property(x => x.SueldoDivisa).HasColumnName(@"SueldoDivisa").HasColumnType("int").IsRequired();
            builder.Property(x => x.Notas).HasColumnName(@"Notas").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.DiasDisponiblesVacaciones).HasColumnName(@"DiasDisponiblesVacaciones").HasColumnType("int").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.Departamento).WithMany(b => b.UsuarioInformacions).HasForeignKey(c => c.IdDepartamento).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UsuarioInformacion_Departamento");
            builder.HasOne(a => a.Divisa).WithMany(b => b.UsuarioInformacions).HasForeignKey(c => c.SueldoDivisa).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UsuarioInformacion_Divisa");
            builder.HasOne(a => a.Empresa).WithMany(b => b.UsuarioInformacions).HasForeignKey(c => c.IdEmpresa).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UsuarioInformacion_Empresa");
            builder.HasOne(a => a.EstadoCivil).WithMany(b => b.UsuarioInformacions).HasForeignKey(c => c.IdEstadoCivil).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UsuarioInformacion_EstadoCivil");
            builder.HasOne(a => a.NivelEstudio).WithMany(b => b.UsuarioInformacions).HasForeignKey(c => c.IdNivelEstudio).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UsuarioInformacion_NivelEstudio");
            builder.HasOne(a => a.Pai).WithMany(b => b.UsuarioInformacions).HasForeignKey(c => c.IdPais).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UsuarioInformacion_Pais");
            builder.HasOne(a => a.Pronombre).WithMany(b => b.UsuarioInformacions).HasForeignKey(c => c.IdPronombre).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UsuarioInformacion_Pronombre");
            builder.HasOne(a => a.TallaPlayera).WithMany(b => b.UsuarioInformacions).HasForeignKey(c => c.IdTallaPlayera).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UsuarioInformacion_TallaPlayera");
            builder.HasOne(a => a.TipoContrato).WithMany(b => b.UsuarioInformacions).HasForeignKey(c => c.IdTipoContrato).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UsuarioInformacion_TipoContrato");
            builder.HasOne(a => a.UsuarioLogin_IdSupervisor).WithMany(b => b.UsuarioInformacions).HasForeignKey(c => c.IdSupervisor).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UsuarioInformacion_Supervisor");
            builder.HasOne(a => a.UsuarioLogin_IdUsuarioLogin).WithOne(b => b.UsuarioInformacion).HasForeignKey<UsuarioInformacion>(c => c.IdUsuarioLogin).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UsuarioInformacion_UsuarioLogin");

            builder.HasIndex(x => x.NumeroSeguroSocial).HasDatabaseName("UQ__UsuarioI__4B6490811A110918").IsUnique();
            builder.HasIndex(x => x.NumeroColaborador).HasDatabaseName("UQ__UsuarioI__672E3C39969E54E2").IsUnique();
            builder.HasIndex(x => x.IdentificadorNacional).HasDatabaseName("UQ__UsuarioI__76712BA3CE15A48A").IsUnique();
            builder.HasIndex(x => x.Rfc).HasDatabaseName("UQ__UsuarioI__CAFFA85E37A82D25").IsUnique();
            builder.HasIndex(x => x.Curp).HasDatabaseName("UQ__UsuarioI__F46C4CBF12446C4B").IsUnique();
        }
    }
}
