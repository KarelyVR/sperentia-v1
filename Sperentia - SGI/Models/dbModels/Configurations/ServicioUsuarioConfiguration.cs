using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // ServicioUsuario
    public class ServicioUsuarioConfiguration : IEntityTypeConfiguration<ServicioUsuario>
    {
        public void Configure(EntityTypeBuilder<ServicioUsuario> builder)
        {
            builder.ToTable("ServicioUsuario", "dbo");
            builder.HasKey(x => new { x.IdServicio, x.IdUsuario }).HasName("PK__Servicio__487AA25BF6517A1A").IsClustered();

            builder.Property(x => x.IdServicio).HasColumnName(@"IdServicio").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.IdUsuario).HasColumnName(@"IdUsuario").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.FechaAsignacion).HasColumnName(@"FechaAsignacion").HasColumnType("date").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.Servicio).WithMany(b => b.ServicioUsuarios).HasForeignKey(c => c.IdServicio).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ServicioUsuario_Servicio");
            builder.HasOne(a => a.UsuarioLogin).WithMany(b => b.ServicioUsuarios).HasForeignKey(c => c.IdUsuario).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ServicioUsuario_Usuario");
        }
    }
}
