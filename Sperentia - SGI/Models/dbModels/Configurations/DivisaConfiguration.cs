using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // Divisa
    public class DivisaConfiguration : IEntityTypeConfiguration<Divisa>
    {
        public void Configure(EntityTypeBuilder<Divisa> builder)
        {
            builder.ToTable("Divisa", "dbo");
            builder.HasKey(x => x.IdDivisa).HasName("PK__Divisa__DA960DCBE9A209AB").IsClustered();

            builder.Property(x => x.IdDivisa).HasColumnName(@"IdDivisa").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Nombre).HasColumnName(@"Nombre").HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50);
            builder.Property(x => x.Codigo).HasColumnName(@"Codigo").HasColumnType("nvarchar(10)").IsRequired().HasMaxLength(10);

            builder.HasIndex(x => x.Codigo).HasDatabaseName("UQ__Divisa__06370DAC55DB37EE").IsUnique();
            builder.HasIndex(x => x.Nombre).HasDatabaseName("UQ__Divisa__75E3EFCF154D5815").IsUnique();
        }
    }
}
