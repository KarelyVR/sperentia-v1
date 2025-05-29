using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // InventarioGeneral
    public class InventarioGeneralConfiguration : IEntityTypeConfiguration<InventarioGeneral>
    {
        public void Configure(EntityTypeBuilder<InventarioGeneral> builder)
        {
            builder.ToTable("InventarioGeneral", "dbo");
            builder.HasKey(x => x.IdInventario).HasName("PK__Inventar__1927B20CB37CD388").IsClustered();

            builder.Property(x => x.IdInventario).HasColumnName(@"IdInventario").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.Marca).HasColumnName(@"Marca").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.Modelo).HasColumnName(@"Modelo").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.NumeroSerie).HasColumnName(@"NumeroSerie").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.EstadoCondicion).HasColumnName(@"EstadoCondicion").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.GarantiaFechaFin).HasColumnName(@"GarantiaFechaFin").HasColumnType("date").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.Inventario).WithOne(b => b.InventarioGeneral).HasForeignKey<InventarioGeneral>(c => c.IdInventario).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_InventarioGeneral_Inventario");
        }
    }
}
