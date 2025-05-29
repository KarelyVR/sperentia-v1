using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // Pais
    public class PaisConfiguration : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("Pais", "dbo");
            builder.HasKey(x => x.IdPais).HasName("PK__Pais__FC850A7BE374204E").IsClustered();

            builder.Property(x => x.IdPais).HasColumnName(@"IdPais").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Nombre).HasColumnName(@"Nombre").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);

            builder.HasIndex(x => x.Nombre).HasDatabaseName("UQ__Pais__75E3EFCFE0C99BBD").IsUnique();
        }
    }
}
