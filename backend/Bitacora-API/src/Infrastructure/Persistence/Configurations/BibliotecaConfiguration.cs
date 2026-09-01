using Bitacora_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitacora_API.Infrastructure.Persistence.Configurations
{
    public class BibliotecaConfiguration : IEntityTypeConfiguration<Biblioteca>
    {
        public void Configure(EntityTypeBuilder<Biblioteca> builder)
        {
            builder.ToTable("bibliotecas");

            builder.HasKey(b => new { b.UsuarioId, b.EdicionId });

            builder.Property(b => b.FechaAgregado).HasColumnName("fecha_agregado")
                .HasDefaultValueSql("CURRENT_TIMESTAMP").IsRequired();

            builder.HasOne(b => b.Usuario).WithMany(u => u.Bibliotecas)
                .HasForeignKey(b => b.UsuarioId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.Edicion).WithMany(e => e.Bibliotecas)
                .HasForeignKey(b => b.EdicionId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}