using Bitacora_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitacora_API.Infrastructure.Persistence.Configurations
{
    public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.ToTable("generos");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id).HasColumnName("id");

            builder.Property(g => g.Nombre).HasColumnName("nombre").HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(g => g.Nombre).IsUnique();
        }
    }
}