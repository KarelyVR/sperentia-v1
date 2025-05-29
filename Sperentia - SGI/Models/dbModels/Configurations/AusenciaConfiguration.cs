using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // Ausencia
    public class AusenciaConfiguration : IEntityTypeConfiguration<Ausencia>
    {
        public void Configure(EntityTypeBuilder<Ausencia> builder)
        {
            builder.ToTable("Ausencia", "dbo");
            builder.HasKey(x => x.IdAusencia).HasName("PK__Ausencia__0B5BA4140848C245").IsClustered();

            builder.Property(x => x.IdAusencia).HasColumnName(@"IdAusencia").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.IdUsuario).HasColumnName(@"IdUsuario").HasColumnType("int").IsRequired();
            builder.Property(x => x.FechaInicio).HasColumnName(@"FechaInicio").HasColumnType("date").IsRequired();
            builder.Property(x => x.FechaFin).HasColumnName(@"FechaFin").HasColumnType("date").IsRequired(false);
            builder.Property(x => x.MotivoAusencia).HasColumnName(@"MotivoAusencia").HasColumnType("nvarchar(500)").IsRequired(false).HasMaxLength(500);

            // Foreign keys
            builder.HasOne(a => a.UsuarioLogin).WithMany(b => b.Ausencias).HasForeignKey(c => c.IdUsuario).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Ausencia_Usuario");
        }
    }
}
