using Bitacora_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitacora_API.Infrastructure.Persistence.Configurations
{
    public class AutorConfiguration : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("autores");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("id");

            builder.Property(a => a.Nombre).HasColumnName("nombre").IsRequired()
                .HasMaxLength(200);

            builder.Property(a => a.Biografia).HasColumnName("biografia");
        }
    }
}