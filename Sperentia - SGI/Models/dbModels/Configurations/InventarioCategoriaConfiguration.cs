using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // InventarioCategoria
    public class InventarioCategoriaConfiguration : IEntityTypeConfiguration<InventarioCategoria>
    {
        public void Configure(EntityTypeBuilder<InventarioCategoria> builder)
        {
            builder.ToTable("InventarioCategoria", "dbo");
            builder.HasKey(x => x.IdCategoria).HasName("PK__Inventar__A3C02A10AD3B8676").IsClustered();

            builder.Property(x => x.IdCategoria).HasColumnName(@"IdCategoria").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Nombre).HasColumnName(@"Nombre").HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50);

            builder.HasIndex(x => x.Nombre).HasDatabaseName("UQ__Inventar__75E3EFCF85CBA72C").IsUnique();
        }
    }
}
