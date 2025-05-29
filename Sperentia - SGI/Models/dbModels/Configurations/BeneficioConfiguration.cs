using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // Beneficio
    public class BeneficioConfiguration : IEntityTypeConfiguration<Beneficio>
    {
        public void Configure(EntityTypeBuilder<Beneficio> builder)
        {
            builder.ToTable("Beneficio", "dbo");
            builder.HasKey(x => x.IdBeneficio).HasName("PK__Benefici__14B7CA0C1D118B54").IsClustered();

            builder.Property(x => x.IdBeneficio).HasColumnName(@"IdBeneficio").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Nombre).HasColumnName(@"Nombre").HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50);
            builder.Property(x => x.Descripcion).HasColumnName(@"Descripcion").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);

            builder.HasIndex(x => x.Nombre).HasDatabaseName("UQ__Benefici__75E3EFCF5716E1CD").IsUnique();
        }
    }
}
