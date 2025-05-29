using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // SolicitudVacacionesDias
    public class SolicitudVacacionesDiaConfiguration : IEntityTypeConfiguration<SolicitudVacacionesDia>
    {
        public void Configure(EntityTypeBuilder<SolicitudVacacionesDia> builder)
        {
            builder.ToTable("SolicitudVacacionesDias", "dbo");
            builder.HasKey(x => new { x.IdSolicitud, x.Fecha }).HasName("PK__Solicitu__DDB9544A027BF603").IsClustered();

            builder.Property(x => x.IdSolicitud).HasColumnName(@"IdSolicitud").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.Fecha).HasColumnName(@"Fecha").HasColumnType("date").IsRequired().ValueGeneratedNever();

            // Foreign keys
            builder.HasOne(a => a.SolicitudVacacione).WithMany(b => b.SolicitudVacacionesDias).HasForeignKey(c => c.IdSolicitud).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SolicitudVacacionesDias_Solicitud");
        }
    }
}
