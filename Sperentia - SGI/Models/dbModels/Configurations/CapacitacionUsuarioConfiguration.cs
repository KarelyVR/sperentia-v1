using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // CapacitacionUsuario
    public class CapacitacionUsuarioConfiguration : IEntityTypeConfiguration<CapacitacionUsuario>
    {
        public void Configure(EntityTypeBuilder<CapacitacionUsuario> builder)
        {
            builder.ToTable("CapacitacionUsuario", "dbo");
            builder.HasKey(x => x.IdCapacitacion).HasName("PK__Capacita__B3A1D353BA92BC63").IsClustered();

            builder.Property(x => x.IdCapacitacion).HasColumnName(@"IdCapacitacion").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.IdUsuario).HasColumnName(@"IdUsuario").HasColumnType("int").IsRequired();
            builder.Property(x => x.IdCapacitacionTipo).HasColumnName(@"IdCapacitacionTipo").HasColumnType("int").IsRequired();
            builder.Property(x => x.Nombre).HasColumnName(@"Nombre").HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50);

            // Foreign keys
            builder.HasOne(a => a.CapacitacionTipo).WithMany(b => b.CapacitacionUsuarios).HasForeignKey(c => c.IdCapacitacionTipo).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CapacitacionUsuario_CapacitacionTipo");
            builder.HasOne(a => a.UsuarioLogin).WithMany(b => b.CapacitacionUsuarios).HasForeignKey(c => c.IdUsuario).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CapacitacionUsuario_Usuario");
        }
    }
}
