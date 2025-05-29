using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // TallaPlayera
    public class TallaPlayeraConfiguration : IEntityTypeConfiguration<TallaPlayera>
    {
        public void Configure(EntityTypeBuilder<TallaPlayera> builder)
        {
            builder.ToTable("TallaPlayera", "dbo");
            builder.HasKey(x => x.IdTallaPlayera).HasName("PK__TallaPla__7F77601606E4CDD9").IsClustered();

            builder.Property(x => x.IdTallaPlayera).HasColumnName(@"IdTallaPlayera").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Talla).HasColumnName(@"Talla").HasColumnType("nvarchar(10)").IsRequired().HasMaxLength(10);

            builder.HasIndex(x => x.Talla).HasDatabaseName("UQ__TallaPla__69DA116124DB2005").IsUnique();
        }
    }
}
