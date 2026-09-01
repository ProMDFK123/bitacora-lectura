using Bitacora_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitacora_API.Infrastructure.Persistence.Configurations
{
    public class ObraConfiguration : IEntityTypeConfiguration<Obra>
    {
        public void Configure(EntityTypeBuilder<Obra> builder)
        {
            builder.ToTable("obras");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id).HasColumnName("id");

            builder.Property(o => o.Titulo).HasColumnName("titulo").HasMaxLength(255)
                .IsRequired();

            builder.Property(o => o.Descripcion).HasColumnName("sinopsis")
                .HasMaxLength(1000);

            builder.Property(o => o.TipoObra).HasColumnName("tipo_obra")
                .HasMaxLength(50).IsRequired();

            builder.Property(o => o.Publicacion).HasColumnName("fecha_publicacion");
            
            builder.Property(o => o.SagaId).HasColumnName("saga_id");

            builder.HasOne(o => o.Saga).WithMany(s => s.Obras).HasForeignKey(o => o.SagaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}