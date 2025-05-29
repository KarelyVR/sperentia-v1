using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // Direccion
    public class DireccionConfiguration : IEntityTypeConfiguration<Direccion>
    {
        public void Configure(EntityTypeBuilder<Direccion> builder)
        {
            builder.ToTable("Direccion", "dbo");
            builder.HasKey(x => x.IdDireccion).HasName("PK__Direccio__1F8E0C76D3DAB651").IsClustered();

            builder.Property(x => x.IdDireccion).HasColumnName(@"IdDireccion").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.IdUsuario).HasColumnName(@"IdUsuario").HasColumnType("int").IsRequired();
            builder.Property(x => x.Direccion_).HasColumnName(@"Direccion").HasColumnType("nvarchar(500)").IsRequired().HasMaxLength(500);
            builder.Property(x => x.Latitud).HasColumnName(@"Latitud").HasColumnType("decimal(9,6)").HasPrecision(9, 6).IsRequired(false);
            builder.Property(x => x.Longitud).HasColumnName(@"Longitud").HasColumnType("decimal(9,6)").HasPrecision(9, 6).IsRequired(false);
            builder.Property(x => x.GoogleMapsUrl).HasColumnName(@"GoogleMapsUrl").HasColumnType("nvarchar(500)").IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.ComprobanteDomicilioUrl).HasColumnName(@"ComprobanteDomicilioUrl").HasColumnType("nvarchar(500)").IsRequired().HasMaxLength(500);

            // Foreign keys
            builder.HasOne(a => a.UsuarioLogin).WithMany(b => b.Direccions).HasForeignKey(c => c.IdUsuario).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Direccion_Usuario");
        }
    }
}
