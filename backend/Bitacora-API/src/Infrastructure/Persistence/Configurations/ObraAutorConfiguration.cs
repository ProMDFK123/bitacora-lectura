using Bitacora_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitacora_API.Infrastructure.Persistence.Configurations
{
    public class ObraAutorConfiguration : IEntityTypeConfiguration<ObraAutor>
    {
        public void Configure(EntityTypeBuilder<ObraAutor> builder)
        {
            builder.ToTable("obra_autor");

            builder.HasKey(oa => new { oa.ObraId, oa.AutorId });

            builder.HasOne(oa => oa.Obra).WithMany().HasForeignKey(oa => oa.ObraId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(oa => oa.Autor).WithMany().HasForeignKey(oa => oa.AutorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}