using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Sperientia___SGI.Models.dbModels.Configurations
{
    // Departamento
    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("Departamento", "dbo");
            builder.HasKey(x => x.IdDepartamento).HasName("PK__Departam__787A433D36EBF1C2").IsClustered();

            builder.Property(x => x.IdDepartamento).HasColumnName(@"IdDepartamento").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Nombre).HasColumnName(@"Nombre").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);

            builder.HasIndex(x => x.Nombre).HasDatabaseName("UQ__Departam__75E3EFCF06D554EB").IsUnique();
        }
    }
}
