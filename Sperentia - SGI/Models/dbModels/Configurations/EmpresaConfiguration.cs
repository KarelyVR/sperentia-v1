using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // Empresa
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa", "dbo");
            builder.HasKey(x => x.IdEmpresa).HasName("PK__Empresa__5EF4033E05E4F6AB").IsClustered();

            builder.Property(x => x.IdEmpresa).HasColumnName(@"IdEmpresa").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Nombre).HasColumnName(@"Nombre").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);

            builder.HasIndex(x => x.Nombre).HasDatabaseName("UQ__Empresa__75E3EFCF5E153627").IsUnique();
        }
    }
}
