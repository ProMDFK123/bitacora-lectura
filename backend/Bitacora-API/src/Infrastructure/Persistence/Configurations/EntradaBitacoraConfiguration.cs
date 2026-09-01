using Bitacora_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitacora_API.Infrastructure.Persistence.Configurations
{
    public class EntradaBitacoraConfiguration : IEntityTypeConfiguration<EntradaBitacora>
    {
        public void Configure(EntityTypeBuilder<EntradaBitacora> builder)
        {
            builder.ToTable("entradas_bitacora");

            builder.HasKey(eb => eb.Id);

            builder.Property(eb => eb.Id).HasColumnName("id");

            builder.Property(eb => eb.LecturaId).HasColumnName("lectura_id")
                .IsRequired();

            builder.Property(eb => eb.SesionLecturaId).HasColumnName("sesio_lectura_id");

            builder.Property(eb => eb.Fecha).HasColumnName("fecha").IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(eb => eb.Titulo).HasColumnName("titulo").IsRequired()
                .HasMaxLength(100);

            builder.Property(eb => eb.Contenido).HasColumnName("contenido").IsRequired();

            builder.Property(eb => eb.Spoilers).HasColumnName("contiene_spoilers")
                .HasDefaultValue(false).IsRequired();

            builder.HasOne(eb => eb.Lectura).WithMany(l => l.Entradas)
                .HasForeignKey(eb => eb.LecturaId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(eb => eb.SesionLectura).WithMany(sl => sl.Entradas)
                .HasForeignKey(eb => eb.SesionLecturaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}