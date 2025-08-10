using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orienta.Domain.Entities;

namespace Orienta.Infrastructure.Persistence.Configurations;

public class ProfessorConfiguration : BaseConfiguration<ProfessorEntity>
{
    public override void ConfigureOtherProperties(EntityTypeBuilder<ProfessorEntity> builder)
    {
        builder.ToTable("professores");
    }
}