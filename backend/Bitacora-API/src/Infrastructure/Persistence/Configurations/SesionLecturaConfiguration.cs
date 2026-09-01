using Bitacora_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitacora_API.Infrastructure.Persistence.Configurations
{
    public class SesionLecturaConfiguration : IEntityTypeConfiguration<SesionLectura>
    {
        public void Configure(EntityTypeBuilder<SesionLectura> builder)
        {
            builder.ToTable("sesiones_lectura");

            builder.HasKey(sl => sl.Id);

            builder.Property(sl => sl.Id).HasColumnName("id");

            builder.Property(sl => sl.LecturaId).HasColumnName("lectura_id")
                .IsRequired();

            builder.Property(sl => sl.Fecha).HasColumnName("fecha").IsRequired();

            builder.Property(sl => sl.Progreso).HasColumnName("progreso")
                .HasPrecision(10, 2).IsRequired();

            builder.Property(sl => sl.Minutos).HasColumnName("duracion_minutos");

            builder.HasOne(sl => sl.Lectura).WithMany(l => l.Sesiones)
                .HasForeignKey(sl => sl.LecturaId).OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(sl => new { sl.LecturaId, sl.Fecha });
        }
    }
}