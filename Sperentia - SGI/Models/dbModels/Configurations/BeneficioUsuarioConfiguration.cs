using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // BeneficioUsuario
    public class BeneficioUsuarioConfiguration : IEntityTypeConfiguration<BeneficioUsuario>
    {
        public void Configure(EntityTypeBuilder<BeneficioUsuario> builder)
        {
            builder.ToTable("BeneficioUsuario", "dbo");
            builder.HasKey(x => new { x.IdUsuarioInformacion, x.IdBeneficio }).HasName("PK__Benefici__94AE11924D7993CA").IsClustered();

            builder.Property(x => x.IdUsuarioInformacion).HasColumnName(@"IdUsuarioInformacion").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.IdBeneficio).HasColumnName(@"IdBeneficio").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.EstaAsignado).HasColumnName(@"EstaAsignado").HasColumnType("bit").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.Beneficio).WithMany(b => b.BeneficioUsuarios).HasForeignKey(c => c.IdBeneficio).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_BeneficioUsuario_Beneficio");
            builder.HasOne(a => a.UsuarioLogin).WithMany(b => b.BeneficioUsuarios).HasForeignKey(c => c.IdUsuarioInformacion).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_BeneficioUsuario_Usuario");
        }
    }
}
