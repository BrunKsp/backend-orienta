using Orienta.Application.DTOs.Perguntas;
using Orienta.Application.DTOs.Questionario;
using Orienta.Application.Exceptions;
using Orienta.Domain.Contracts;
using Orienta.Domain.Entities;
using Orienta.Domain.Enums;
using Orienta.Infrastructure.Repositories;

namespace Orienta.Application.UseCases.Usuario;

public class CriarUsuarioUseCase
{
    private readonly IQuestionarioFactoryProvider _factoryProvider;
    private readonly IQuestionarioRepository _repository;

    public CriarUsuarioUseCase(
        IQuestionarioFactoryProvider factoryProvider,
        IQuestionarioRepository repository)
    {
        _factoryProvider = factoryProvider;
        _repository = repository;
    }

    public async Task ExecuteAsync(CriarQuestionarioDto dto)
    {
        if (dto.Perguntas == null || !dto.Perguntas.Any())
            throw CustomException.ErroValidacao(new { error = "É necessário enviar pelo menos uma pergunta." });
        var perguntas = dto.Perguntas.Select(p =>
            new PerguntaEntity(
                Guid.Empty,
                p.Enunciado,
                (TipoPergunta)p.Tipo,
                p.Alternativas?.Select(a => new AlternativaEntity(a.Texto, a.Correta)).ToList(),
                p.RespostaEsperada
            )).ToList();

        var factory = _factoryProvider.Resolver(dto.Tipo);
        var questionario = factory.Criar(dto.Titulo, dto.Descricao, dto.ProfessorSlug, perguntas);
        await _repository.Criar(questionario);
    }
}
