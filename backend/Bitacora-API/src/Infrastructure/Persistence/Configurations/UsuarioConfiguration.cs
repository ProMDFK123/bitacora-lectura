using Bitacora_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitacora_API.Infrastructure.Persistence.Configurations
{
   public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).HasColumnName("id");

            builder.Property(u => u.Nombre).HasColumnName("nombre").IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email).HasColumnName("email").HasMaxLength(255)
                .IsRequired();

            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.PasswordHash)
                .HasColumnName("contrasena_hasheada").IsRequired().HasMaxLength(255);

            builder.Property(u => u.FechaCreacion).HasColumnName("fecha_registro")
                .HasDefaultValueSql("CURRENT_TIMESTAMP").IsRequired();

            builder.Property(u => u.Activo).HasColumnName("activo").IsRequired()
                .HasDefaultValue(true);
        }
    }
}