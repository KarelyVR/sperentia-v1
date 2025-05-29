using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // InventarioAsignacion
    public class InventarioAsignacionConfiguration : IEntityTypeConfiguration<InventarioAsignacion>
    {
        public void Configure(EntityTypeBuilder<InventarioAsignacion> builder)
        {
            builder.ToTable("InventarioAsignacion", "dbo");
            builder.HasKey(x => new { x.IdInventario, x.IdUsuario }).HasName("PK__Inventar__7C91E9F51745367F").IsClustered();

            builder.Property(x => x.IdInventario).HasColumnName(@"IdInventario").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.IdUsuario).HasColumnName(@"IdUsuario").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.FechaEntrega).HasColumnName(@"FechaEntrega").HasColumnType("date").IsRequired();
            builder.Property(x => x.FechaDevolucion).HasColumnName(@"FechaDevolucion").HasColumnType("date").IsRequired(false);
            builder.Property(x => x.Nota).HasColumnName(@"Nota").HasColumnType("nvarchar(500)").IsRequired(false).HasMaxLength(500);

            // Foreign keys
            builder.HasOne(a => a.Inventario).WithMany(b => b.InventarioAsignacions).HasForeignKey(c => c.IdInventario).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_InventarioAsignacion_Inventario");
            builder.HasOne(a => a.UsuarioLogin).WithMany(b => b.InventarioAsignacions).HasForeignKey(c => c.IdUsuario).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_InventarioAsignacion_Usuario");
        }
    }
}
