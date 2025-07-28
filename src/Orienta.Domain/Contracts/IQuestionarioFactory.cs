using Orienta.Domain.Entities;

namespace Orienta.Domain.Contracts;

public interface IQuestionarioFactory
{
    QuestionarioEntity Criar(string titulo, string descricao, Guid? professorId, List<PerguntaEntity> perguntas);
}