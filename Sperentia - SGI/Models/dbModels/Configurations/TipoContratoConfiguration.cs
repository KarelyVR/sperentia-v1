using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // TipoContrato
    public class TipoContratoConfiguration : IEntityTypeConfiguration<TipoContrato>
    {
        public void Configure(EntityTypeBuilder<TipoContrato> builder)
        {
            builder.ToTable("TipoContrato", "dbo");
            builder.HasKey(x => x.IdTipoContrato).HasName("PK__TipoCont__F46C49C2E9581F4E").IsClustered();

            builder.Property(x => x.IdTipoContrato).HasColumnName(@"IdTipoContrato").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Descripcion).HasColumnName(@"Descripcion").HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50);

            builder.HasIndex(x => x.Descripcion).HasDatabaseName("UQ__TipoCont__92C53B6C0FE1466A").IsUnique();
        }
    }
}
