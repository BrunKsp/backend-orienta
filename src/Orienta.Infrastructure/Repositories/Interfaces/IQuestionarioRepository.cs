using Orienta.Domain.Entities;

namespace Orienta.Infrastructure.Repositories;

public interface IQuestionarioRepository
{
    Task SalvarAsync(QuestionarioEntity questionario);
}