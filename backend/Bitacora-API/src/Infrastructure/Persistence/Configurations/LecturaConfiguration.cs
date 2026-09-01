using Bitacora_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitacora_API.Infrastructure.Persistence.Configurations
{
    public class LecturaConfiguration : IEntityTypeConfiguration<Lectura>
    {
        public void Configure(EntityTypeBuilder<Lectura> builder)
        {
            builder.ToTable("lecturas");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Id).HasColumnName("id");

            builder.Property(l => l.UsuarioId).HasColumnName("usuario_id")
                .IsRequired();

            builder.Property(l => l.EdicionId).HasColumnName("edicion_id")
                .IsRequired();

            builder.Property(l => l.FechaInicio).HasColumnName("fecha_inicio")
                .IsRequired();

            builder.Property(l => l.FechaFin).HasColumnName("fecha_fin");

            builder.Property(l => l.Estado).HasColumnName("estado").IsRequired()
                .HasMaxLength(20);

            builder.Property(l => l.NumeroRelecturas).HasColumnName("numero_relecturas")
                .IsRequired();

            builder.HasOne(l => l.Usuario).WithMany(u => u.Lecturas)
                .HasForeignKey(l => l.UsuarioId).OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(l => new { l.UsuarioId, l.EdicionId, 
                l.NumeroRelecturas}).IsUnique();
        }
    }
}