using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orienta.Domain.Entities;

namespace Orienta.Infrastructure.Persistence.Configurations;

public class AlunoConfiguration : BaseConfiguration<AlunoEntity>
{
    public override void ConfigureOtherProperties(EntityTypeBuilder<AlunoEntity> builder)
    {
        builder.ToTable("alunos");
    }
}