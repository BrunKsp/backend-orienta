using Orienta.Domain.Entities;

namespace Orienta.Domain.Contracts;

public interface IQuestionarioFactory
{
    QuestionarioEntity Criar(string titulo, string descricao, string professorSlug, List<PerguntaEntity> perguntas);
}