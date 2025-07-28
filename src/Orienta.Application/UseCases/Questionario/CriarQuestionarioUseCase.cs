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
        List<PerguntaEntity> perguntas,
        QuestionarioFactoryType tipo)
    {
        var factory = _factoryProvider.Resolver(tipo);
        var questionario = factory.Criar(titulo, descricao, professorId, perguntas);
        await _repository.SalvarAsync(questionario);
    }
}
