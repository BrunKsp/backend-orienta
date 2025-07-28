using Orienta.Domain.Entities;

using Orienta.Infrastructure.Persistence;

namespace Orienta.Infrastructure.Repositories;

public class QuestionarioRepository : BaseRepository<QuestionarioEntity>, IQuestionarioRepository
{
    public QuestionarioRepository(OrientaDbContext context) : base(context) { }
}
