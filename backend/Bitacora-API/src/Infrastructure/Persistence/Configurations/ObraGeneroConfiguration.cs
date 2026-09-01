using Bitacora_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitacora_API.Infrastructure.Persistence.Configurations
{
    public class ObraGeneroConfiguration : IEntityTypeConfiguration<ObraGenero>
    {
        public void Configure(EntityTypeBuilder<ObraGenero> builder)
        {
            builder.ToTable("obra_genero");

            builder.HasKey(og => new { og.ObraId, og.GeneroId });

            builder.HasOne(og => og.Obra).WithMany().HasForeignKey(og => og.ObraId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(og => og.Genero).WithMany().HasForeignKey(og => og.GeneroId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}