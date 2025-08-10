using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orienta.Domain.Entities;

namespace Orienta.Infrastructure.Persistence.Configurations;

public class RespostaConfiguration : BaseConfiguration<RespostaEntity>
{
    public override void ConfigureOtherProperties(EntityTypeBuilder<RespostaEntity> builder)
    {
        builder.ToTable("respostas");

        builder.Property(r => r.AlunoId)
           .HasColumnName("aluno_id");

        builder.Property(r => r.QuestionarioId)
            .HasColumnName("questioario_id");

        builder.HasOne(r => r.Aluno)
            .WithMany()
            .HasForeignKey(r => r.AlunoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.Questionario)
            .WithMany()
            .HasForeignKey(r => r.QuestionarioId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(r => r.RespostasPerguntas)
            .WithOne(rp => rp.Resposta)
            .HasForeignKey(rp => rp.RespostaId);
    }
}