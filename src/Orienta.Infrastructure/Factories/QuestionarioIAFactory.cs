using Orienta.Domain.Contracts;
using Orienta.Domain.Entities;

namespace Orienta.Infrastructure.Factories;

public class QuestionarioIAFactory : IQuestionarioFactory
{
    public QuestionarioEntity Criar(string titulo, string? descricao, Guid? professorId, List<PerguntaEntity> perguntas)
    {
        var tituloIA = $"[IA] {titulo}";
        return new QuestionarioEntity(tituloIA, descricao, null, perguntas);
    }
}