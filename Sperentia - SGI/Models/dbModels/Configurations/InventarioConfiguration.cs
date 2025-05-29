using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // Inventario
    public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
    {
        public void Configure(EntityTypeBuilder<Inventario> builder)
        {
            builder.ToTable("Inventario", "dbo");
            builder.HasKey(x => x.IdInventario).HasName("PK__Inventar__1927B20C818BEB6A").IsClustered();

            builder.Property(x => x.IdInventario).HasColumnName(@"IdInventario").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.CodigoInterno).HasColumnName(@"CodigoInterno").HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50);
            builder.Property(x => x.Foto).HasColumnName(@"Foto").HasColumnType("nvarchar(500)").IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.Nombre).HasColumnName(@"Nombre").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Descripcion).HasColumnName(@"Descripcion").HasColumnType("nvarchar(500)").IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.IdCategoria).HasColumnName(@"IdCategoria").HasColumnType("int").IsRequired();
            builder.Property(x => x.FechaCompra).HasColumnName(@"FechaCompra").HasColumnType("date").IsRequired(false);
            builder.Property(x => x.Costo).HasColumnName(@"Costo").HasColumnType("decimal(10,2)").HasPrecision(10, 2).IsRequired(false);
            builder.Property(x => x.Proveedor).HasColumnName(@"Proveedor").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);

            // Foreign keys
            builder.HasOne(a => a.InventarioCategoria).WithMany(b => b.Inventarios).HasForeignKey(c => c.IdCategoria).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Inventario_Categoria");

            builder.HasIndex(x => x.CodigoInterno).HasDatabaseName("UQ__Inventar__28C92875BD551D87").IsUnique();
        }
    }
}
