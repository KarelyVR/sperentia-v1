using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // Servicio
    public class ServicioConfiguration : IEntityTypeConfiguration<Servicio>
    {
        public void Configure(EntityTypeBuilder<Servicio> builder)
        {
            builder.ToTable("Servicio", "dbo");
            builder.HasKey(x => x.IdServicio).HasName("PK__Servicio__2DCCF9A299E17E3D").IsClustered();

            builder.Property(x => x.IdServicio).HasColumnName(@"IdServicio").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Nombre).HasColumnName(@"Nombre").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Costo).HasColumnName(@"Costo").HasColumnType("decimal(10,2)").HasPrecision(10, 2).IsRequired();
            builder.Property(x => x.CostoDivisa).HasColumnName(@"CostoDivisa").HasColumnType("int").IsRequired();
            builder.Property(x => x.CostoFrecuencia).HasColumnName(@"CostoFrecuencia").HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50);
            builder.Property(x => x.MetodoPago).HasColumnName(@"MetodoPago").HasColumnType("nvarchar(100)").IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.FechaAdquisicion).HasColumnName(@"FechaAdquisicion").HasColumnType("date").IsRequired(false);
            builder.Property(x => x.CuentaRegistrada).HasColumnName(@"CuentaRegistrada").HasColumnType("nvarchar(256)").IsRequired(false).HasMaxLength(256);
            builder.Property(x => x.Contrasena).HasColumnName(@"Contrasena").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.UltimaModificacionContrasena).HasColumnName(@"UltimaModificacionContrasena").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.Url).HasColumnName(@"URL").HasColumnType("nvarchar(500)").IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.Notas).HasColumnName(@"Notas").HasColumnType("nvarchar(1000)").IsRequired(false).HasMaxLength(1000);

            // Foreign keys
            builder.HasOne(a => a.Divisa).WithMany(b => b.Servicios).HasForeignKey(c => c.CostoDivisa).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Servicio_Divisa");
        }
    }
}
