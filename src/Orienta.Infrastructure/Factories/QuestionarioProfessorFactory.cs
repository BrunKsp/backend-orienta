using Orienta.Domain.Contracts;
using Orienta.Domain.Entities;
using Orienta.Domain.Enums;

namespace Orienta.Infrastructure.Factories;

public class QuestionarioProfessorFactory : IQuestionarioFactory
{
    public QuestionarioEntity Criar(string titulo, string? descricao, string professorSlug, List<PerguntaEntity> perguntas)
    {
        return new QuestionarioEntity(titulo, descricao, professorSlug, QuestionarioFactoryType.Professor, perguntas);
    }
}