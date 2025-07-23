using Orienta.Domain.Entities;

namespace Orienta.Infrastructure.Factories;

public static class QuestionarioFactory
{
    public static QuestionarioEntity Criar(string titulo, string? descricao, Guid? professorId, List<PerguntaEntity> perguntas)
    {
        var questionario = new QuestionarioEntity(titulo, descricao, professorId);

        foreach (var pergunta in perguntas)
        {
            questionario.AdicionarPergunta(pergunta);
        }

        return questionario;
    }
}
