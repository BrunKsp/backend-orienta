using Orienta.Application.DTOs.Professor;
using Orienta.Application.DTOs.Usuario;
using Orienta.Application.Exceptions;
using Orienta.Application.Factories;
using Orienta.Application.Interfaces;
using Orienta.Domain.Entities;
using Orienta.Domain.Enums;
using Orienta.Infrastructure.Repositories.Interfaces;

namespace Orienta.Application.UseCases.Professor;

public class CriarProfessorUseCase
{
    private readonly IProfessorRepository _repository;
    private readonly IUsuarioFactoryProvider _factoryProvider;
    private readonly IAuthService _authService;

    public CriarProfessorUseCase(IProfessorRepository repository,
                                 IUsuarioFactoryProvider factoryProvider,
                                 IAuthService authService)
    {
        _repository = repository;
        _factoryProvider = factoryProvider;
        _authService = authService;
    }

    public async Task<UsuarioAutenticadoDto> ExecuteAsync(CriarProfessorDto dto)
    {
        var email = dto.Email?.Trim().ToLowerInvariant()
                    ?? throw CustomException.ErroValidacao(new { error = "E-mail é obrigatório." });

        var existente = await _repository.ObterPorEmailAsync(email);
        if (existente is not null)
            throw CustomException.ErroValidacao(new { error = "Já existe esse e-mail." });

        var factory = _factoryProvider.Resolver(TipoUsuario.Professor);
        var usuario = factory.Criar(dto.Nome, dto.Email, dto.Senha, dto.Foto);

        var professor = usuario as ProfessorEntity
            ?? throw CustomException.BadRequest(new { error = "Factory de Professor retornou tipo inválido." });

        await _repository.Criar(professor);
        return _authService.GenerateJWT(professor);
    }
}