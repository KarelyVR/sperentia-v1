using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // SolicitudVacacionesEstatus
    public class SolicitudVacacionesEstatuConfiguration : IEntityTypeConfiguration<SolicitudVacacionesEstatus>
    {
        public void Configure(EntityTypeBuilder<SolicitudVacacionesEstatus> builder)
        {
            builder.ToTable("SolicitudVacacionesEstatus", "dbo");
            builder.HasKey(x => x.IdEstatus).HasName("PK__Solicitu__B32BA1C7F59265F2").IsClustered();

            builder.Property(x => x.IdEstatus).HasColumnName(@"IdEstatus").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Descripcion).HasColumnName(@"Descripcion").HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50);

            builder.HasIndex(x => x.Descripcion).HasDatabaseName("UQ__Solicitu__92C53B6C6C0B418B").IsUnique();
        }
    }
}
