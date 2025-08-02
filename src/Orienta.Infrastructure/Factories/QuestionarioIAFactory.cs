using Orienta.Domain.Contracts;
using Orienta.Domain.Entities;
using Orienta.Domain.Enums;

namespace Orienta.Infrastructure.Factories;

public class QuestionarioIAFactory : IQuestionarioFactory
{
    public QuestionarioEntity Criar(string titulo, string? descricao, string professorSlug, List<PerguntaEntity> perguntas)
    {
        var criadoPor = QuestionarioFactoryType.IA;
        return new QuestionarioEntity(titulo, descricao, null, criadoPor, perguntas);
    }
}