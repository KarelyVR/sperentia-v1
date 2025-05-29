using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // NivelEstudio
    public class NivelEstudioConfiguration : IEntityTypeConfiguration<NivelEstudio>
    {
        public void Configure(EntityTypeBuilder<NivelEstudio> builder)
        {
            builder.ToTable("NivelEstudio", "dbo");
            builder.HasKey(x => x.IdNivelEstudio).HasName("PK__NivelEst__FF408A03D08D14CA").IsClustered();

            builder.Property(x => x.IdNivelEstudio).HasColumnName(@"IdNivelEstudio").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Descripcion).HasColumnName(@"Descripcion").HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50);

            builder.HasIndex(x => x.Descripcion).HasDatabaseName("UQ__NivelEst__92C53B6CF5C34844").IsUnique();
        }
    }
}
