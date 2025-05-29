using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // InventarioLibro
    public class InventarioLibroConfiguration : IEntityTypeConfiguration<InventarioLibro>
    {
        public void Configure(EntityTypeBuilder<InventarioLibro> builder)
        {
            builder.ToTable("InventarioLibro", "dbo");
            builder.HasKey(x => x.IdInventario).HasName("PK__Inventar__1927B20C6FD6ACD2").IsClustered();

            builder.Property(x => x.IdInventario).HasColumnName(@"IdInventario").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.Autor).HasColumnName(@"Autor").HasColumnType("nvarchar(100)").IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.Reseña).HasColumnName(@"Reseña").HasColumnType("nvarchar(500)").IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.Editorial).HasColumnName(@"Editorial").HasColumnType("nvarchar(100)").IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.Isbn).HasColumnName(@"ISBN").HasColumnType("nvarchar(20)").IsRequired(false).HasMaxLength(20);
            builder.Property(x => x.EsDigital).HasColumnName(@"EsDigital").HasColumnType("bit").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.Inventario).WithOne(b => b.InventarioLibro).HasForeignKey<InventarioLibro>(c => c.IdInventario).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_InventarioLibro_Inventario");
        }
    }
}
