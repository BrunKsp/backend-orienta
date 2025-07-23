using Orienta.Application.DTOs.Questionario;
using Orienta.Domain.Entities;

namespace Orienta.Domain.Factories;

public static class QuestionarioFactory
{
    public static QuestionarioEntity Criar(
        string titulo,
        string descricao,
        Guid? professorId,
        List<PerguntaCriacaoDto> perguntasDto)
    {
        var questionario = new QuestionarioEntity(titulo, descricao, professorId);

        foreach (var perguntaDto in perguntasDto)
        {
            var alternativas = perguntaDto.Alternativas?
                .Select(a => new AlternativaEntity(a.Texto, a.Correta))
                .ToList();

            var pergunta = new PerguntaEntity(
                questionario.Id,
                perguntaDto.Enunciado,
                perguntaDto.Tipo,
                alternativas,
                perguntaDto.RespostaEsperada
            );

            questionario.AdicionarPergunta(pergunta);
        }

        return questionario;
    }
}
