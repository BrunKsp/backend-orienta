using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orienta.Domain.Entities;

namespace Orienta.Infrastructure.Persistence.Configurations;

public class PerguntaConfiguration : BaseConfiguration<PerguntaEntity>
{
    public override void ConfigureOtherProperties(EntityTypeBuilder<PerguntaEntity> builder)
    {
        builder.ToTable("perguntas");

        builder.Property(x => x.QuestionarioId)
            .HasColumnName("questionario_id")
            .IsRequired();

        builder.Property(x => x.Enunciado)
            .HasColumnName("enunciado")
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.Tipo)
            .HasColumnName("tipo")
            .IsRequired();

        builder.Property(x => x.RespostaEsperada)
            .HasColumnName("resposta_esperada")
            .HasMaxLength(500);

        builder.HasMany(p => p.Alternativas)
            .WithOne(a => a.Pergunta)
            .HasForeignKey(a => a.PerguntaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}