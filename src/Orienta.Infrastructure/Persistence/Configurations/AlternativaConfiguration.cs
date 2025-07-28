using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orienta.Domain.Entities;

namespace Orienta.Infrastructure.Persistence.Configurations;

public class AlternativaConfiguration : BaseConfiguration<AlternativaEntity>
{
    public override void ConfigureOtherProperties(EntityTypeBuilder<AlternativaEntity> builder)
    {
        builder.ToTable("alternativas");

        builder.Property(x => x.PerguntaId)
           .HasColumnName("pergunta_id")
           .IsRequired();

        builder.Property(x => x.Texto)
            .HasColumnName("texto")
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.Correta)
            .HasColumnName("correta")
            .IsRequired();

        builder.HasOne(x => x.Pergunta)
            .WithMany(p => p.Alternativas)
            .HasForeignKey(x => x.PerguntaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}