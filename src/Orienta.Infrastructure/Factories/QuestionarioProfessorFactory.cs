using Orienta.Domain.Contracts;
using Orienta.Domain.Entities;

namespace Orienta.Infrastructure.Factories;

public class QuestionarioProfessorFactory : IQuestionarioFactory
{
    public QuestionarioEntity Criar(string titulo, string? descricao, Guid? professorId, List<PerguntaEntity> perguntas)
    {
        return new QuestionarioEntity(titulo, descricao, professorId, perguntas);
    }
}