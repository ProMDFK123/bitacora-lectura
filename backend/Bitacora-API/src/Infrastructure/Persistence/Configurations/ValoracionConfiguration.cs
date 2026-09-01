using Bitacora_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitacora_API.Infrastructure.Persistence.Configurations
{
    public class ValoracionConfiguration : IEntityTypeConfiguration<Valoracion>
    {
        public void Configure(EntityTypeBuilder<Valoracion> builder)
        {
            builder.ToTable("valoraciones");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id).HasColumnName("id");

            builder.Property(v => v.LecturaId).HasColumnName("lectura_id")
                .IsRequired();

            builder.Property(v => v.Puntuacion).HasColumnName("puntuacion")
                .HasPrecision(2, 1).IsRequired();

            builder.Property(v => v.Resena).HasColumnName("resena");

            builder.Property(v => v.Fecha).HasColumnName("fecha").IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(v => v.Lectura).WithOne(l => l.Valoracion)
                .HasForeignKey<Valoracion>(v => v.LecturaId).
                OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(v => v.LecturaId).IsUnique();

            builder.HasCheckConstraint("ck_valoracion_puntuacion", 
                "puntuacion >= 0 AND puntuacion <= 5");
        }
    }
}