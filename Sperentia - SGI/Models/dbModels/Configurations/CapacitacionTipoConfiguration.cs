using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // CapacitacionTipo
    public class CapacitacionTipoConfiguration : IEntityTypeConfiguration<CapacitacionTipo>
    {
        public void Configure(EntityTypeBuilder<CapacitacionTipo> builder)
        {
            builder.ToTable("CapacitacionTipo", "dbo");
            builder.HasKey(x => x.IdCapacitacionTipo).HasName("PK__Capacita__46690681113D0F7B").IsClustered();

            builder.Property(x => x.IdCapacitacionTipo).HasColumnName(@"IdCapacitacionTipo").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Descripcion).HasColumnName(@"Descripcion").HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50);

            builder.HasIndex(x => x.Descripcion).HasDatabaseName("UQ__Capacita__92C53B6C023DF2D4").IsUnique();
        }
    }
}
