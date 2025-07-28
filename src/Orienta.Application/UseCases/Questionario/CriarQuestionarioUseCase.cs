using Orienta.Application.DTOs.Perguntas;
using Orienta.Domain.Contracts;
using Orienta.Domain.Entities;
using Orienta.Domain.Enums;
using Orienta.Infrastructure.Repositories;

namespace Orienta.Application.UseCases.Questionario;

public class CriarQuestionarioUseCase
{
    private readonly IQuestionarioFactoryProvider _factoryProvider;
    private readonly IQuestionarioRepository _repository;

    public CriarQuestionarioUseCase(
        IQuestionarioFactoryProvider factoryProvider,
        IQuestionarioRepository repository)
    {
        _factoryProvider = factoryProvider;
        _repository = repository;
    }

    public async Task ExecuteAsync(
     string titulo,
     string? descricao,
     Guid? professorId,
     List<PerguntaDto> perguntaDtos,
     QuestionarioFactoryType tipo)
    {
        var perguntas = perguntaDtos.Select(p =>
            new PerguntaEntity(
                Guid.Empty,
                p.Enunciado,
                (TipoPergunta)p.Tipo,
                p.Alternativas?.Select(a => new AlternativaEntity(a.Texto, a.Correta)).ToList(),
                p.RespostaEsperada
            )).ToList();

        var factory = _factoryProvider.Resolver(tipo);
        var questionario = factory.Criar(titulo, descricao, professorId, perguntas);
        await _repository.SalvarAsync(questionario);
    }
}
