using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // Pronombre
    public class PronombreConfiguration : IEntityTypeConfiguration<Pronombre>
    {
        public void Configure(EntityTypeBuilder<Pronombre> builder)
        {
            builder.ToTable("Pronombre", "dbo");
            builder.HasKey(x => x.IdPronombre).HasName("PK__Pronombr__36F24BB1DC4D5397").IsClustered();

            builder.Property(x => x.IdPronombre).HasColumnName(@"IdPronombre").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Descripcion).HasColumnName(@"Descripcion").HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50);

            builder.HasIndex(x => x.Descripcion).HasDatabaseName("UQ__Pronombr__92C53B6C782C7B05").IsUnique();
        }
    }
}
