using Bitacora_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitacora_API.Infrastructure.Persistence.Configurations
{
    public class EdicionConfiguration : IEntityTypeConfiguration<Edicion>
    {
        public void Configure(EntityTypeBuilder<Edicion> builder)
        {
            builder.ToTable("ediciones");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.ObraId).HasColumnName("obra_id").IsRequired();

            builder.Property(e => e.Isbn).HasColumnName("isbn").HasMaxLength(20);

            builder.Property(e => e.Editorial).HasColumnName("editorial")
                .HasMaxLength(200);

            builder.Property(e => e.Anio).HasColumnName("anio_publicacion");

            builder.Property(e => e.Paginas).HasColumnName("numero_paginas");

            builder.Property(e => e.PortadaURL).HasColumnName("portada_url")
                .HasMaxLength(1000);

            builder.Property(e => e.Formato).HasColumnName("formato").IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.duracionMinutos).HasColumnName("duracion_minutos");

            builder.HasOne(e => e.Obra).WithMany(o => o.Ediciones)
                .HasForeignKey(e => e.ObraId).OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(e => e.Isbn).IsUnique().HasFilter("isbn IS NOT NULL");
        }
    }
}