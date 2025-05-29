using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // EstadoCivil
    public class EstadoCivilConfiguration : IEntityTypeConfiguration<EstadoCivil>
    {
        public void Configure(EntityTypeBuilder<EstadoCivil> builder)
        {
            builder.ToTable("EstadoCivil", "dbo");
            builder.HasKey(x => x.IdEstadoCivil).HasName("PK__EstadoCi__889DE1B295F28A79").IsClustered();

            builder.Property(x => x.IdEstadoCivil).HasColumnName(@"IdEstadoCivil").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Descripcion).HasColumnName(@"Descripcion").HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50);

            builder.HasIndex(x => x.Descripcion).HasDatabaseName("UQ__EstadoCi__92C53B6CAC8C98BB").IsUnique();
        }
    }
}
