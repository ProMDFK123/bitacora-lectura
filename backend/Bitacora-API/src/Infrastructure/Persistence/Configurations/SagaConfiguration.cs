using Bitacora_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitacora_API.Infrastructure.Persistence.Configurations
{
    public class SagaConfiguration : IEntityTypeConfiguration<Saga>
    {
        public void Configure(EntityTypeBuilder<Saga> builder)
        {
            builder.ToTable("sagas");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id).HasColumnName("id");

            builder.Property(s => s.Nombre).HasColumnName("nombre").IsRequired()
                .HasMaxLength(200);

            builder.Property(s => s.Descripcion).HasColumnName("descripcion");
        }
    }
}