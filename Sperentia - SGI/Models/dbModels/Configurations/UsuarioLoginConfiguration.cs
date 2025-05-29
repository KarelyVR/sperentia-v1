using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // UsuarioLogin
    public class UsuarioLoginConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.NombreCompleto).HasColumnName(@"NombreCompleto").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.FotografiaUrl).HasColumnName(@"FotografiaUrl").HasColumnType("nvarchar(500)").IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.EstaActivo).HasColumnName(@"EstaActivo").HasColumnType("bit").IsRequired();
        }
    }
}
