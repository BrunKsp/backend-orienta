using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orienta.Domain.Entities;

namespace Orienta.Infrastructure.Persistence.Configurations;

public class QuestionarioConfiguration : BaseConfiguration<QuestionarioEntity>
{
    public override void ConfigureOtherProperties(EntityTypeBuilder<QuestionarioEntity> builder)
    {
        builder.ToTable("questionario");

        builder.Property(x => x.Titulo)
            .HasColumnName("titulo")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Descricao)
            .HasColumnName("descricao")
            .HasMaxLength(500);

        builder.Property(x => x.ProfessorSlug)
           .HasColumnName("professor_slug");

        builder.Property(x => x.CriadoPor)
           .HasColumnName("criado_por");

        builder.HasMany(x => x.Perguntas)
            .WithOne()
            .HasForeignKey(p => p.QuestionarioId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
