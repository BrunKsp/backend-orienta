using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orienta.Domain.Entities;

namespace Orienta.Infrastructure.Persistence.Configurations;

public class RespostaPerguntaConfiguration : BaseConfiguration<RespostaPerguntaEntity>
{
    public override void ConfigureOtherProperties(EntityTypeBuilder<RespostaPerguntaEntity> builder)
    {
        builder.ToTable("respostas_perguntas");

        builder.Property(rp => rp.RespostaAluno)
            .HasColumnName("resposta_aluno")
            .IsRequired();

        builder.Property(rp => rp.RespostaId)
            .HasColumnName("resposta_id");

        builder.Property(rp => rp.PerguntaId)
           .HasColumnName("pergunta_id");

        builder.HasOne(rp => rp.Pergunta)
            .WithMany()
            .HasForeignKey(rp => rp.PerguntaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}