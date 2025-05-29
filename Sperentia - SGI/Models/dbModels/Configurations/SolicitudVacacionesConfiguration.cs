using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // SolicitudVacaciones
    public class SolicitudVacacioneConfiguration : IEntityTypeConfiguration<SolicitudVacaciones>
    {
        public void Configure(EntityTypeBuilder<SolicitudVacaciones> builder)
        {
            builder.ToTable("SolicitudVacaciones", "dbo");
            builder.HasKey(x => x.IdSolicitud).HasName("PK__Solicitu__36899CEF4410E6C2").IsClustered();

            builder.Property(x => x.IdSolicitud).HasColumnName(@"IdSolicitud").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.IdEmpleado).HasColumnName(@"IdEmpleado").HasColumnType("int").IsRequired();
            builder.Property(x => x.FechaSolicitud).HasColumnName(@"FechaSolicitud").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DerechoDiasEmpleado).HasColumnName(@"DerechoDiasEmpleado").HasColumnType("int").IsRequired();
            builder.Property(x => x.IdUsuarioRh).HasColumnName(@"IdUsuarioRH").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.IdEstatus).HasColumnName(@"IdEstatus").HasColumnType("int").IsRequired();
            builder.Property(x => x.SustitutoNombre).HasColumnName(@"SustitutoNombre").HasColumnType("nvarchar(100)").IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.SustitutoTelefono).HasColumnName(@"SustitutoTelefono").HasColumnType("nvarchar(20)").IsRequired(false).HasMaxLength(20);

            // Foreign keys
            builder.HasOne(a => a.SolicitudVacacionesEstatu).WithMany(b => b.SolicitudVacaciones).HasForeignKey(c => c.IdEstatus).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SolicitudVacaciones_Estatus");
            builder.HasOne(a => a.UsuarioLogin_IdEmpleado).WithMany(b => b.SolicitudVacaciones_IdEmpleado).HasForeignKey(c => c.IdEmpleado).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SolicitudVacaciones_Empleado");
            builder.HasOne(a => a.UsuarioLogin_IdUsuarioRh).WithMany(b => b.SolicitudVacaciones_IdUsuarioRh).HasForeignKey(c => c.IdUsuarioRh).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SolicitudVacaciones_UsuarioRH");
        }
    }
}
