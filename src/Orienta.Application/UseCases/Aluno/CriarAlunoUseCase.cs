using Orienta.Application.DTOs.Aluno;
using Orienta.Application.DTOs.Usuario;
using Orienta.Application.Exceptions;
using Orienta.Application.Factories;
using Orienta.Application.Interfaces;
using Orienta.Domain.Entities;
using Orienta.Domain.Enums;
using Orienta.Infrastructure.Repositories.Interfaces;
using BC = BCrypt.Net.BCrypt;

namespace Orienta.Application.UseCases.Aluno;

public class CriarAlunoUseCase
{
    private readonly IAlunoRepository _repository;
    private readonly IUsuarioFactoryProvider _factoryProvider;
    private readonly IAuthService _authService;
    public CriarAlunoUseCase(IAuthService authService, IUsuarioFactoryProvider factoryProvider, IAlunoRepository repository)
    {
        _authService = authService;
        _factoryProvider = factoryProvider;
        _repository = repository;
    }

    public async Task<UsuarioAutenticadoDto> ExecuteAsync(CriarAlunoDto dto)
    {
        var email = dto.Email?.Trim().ToLowerInvariant()
                   ?? throw CustomException.ErroValidacao(new { error = "E-mail é obrigatório." });

        var existente = await _repository.ObterPorEmailAsync(email);
        if (existente is not null)
            throw CustomException.ErroValidacao(new { error = "Já existe esse e-mail." });

        var senha = BC.HashPassword(dto.Senha);

        var factory = _factoryProvider.Resolver(TipoUsuario.Aluno);
        var usuario = factory.Criar(dto.Nome, dto.Email, senha, dto.Foto);

        var aluno = usuario as AlunoEntity
            ?? throw CustomException.ErroValidacao(new { error = "Factory de Professor retornou tipo inválido." });

        await _repository.Criar(aluno);
        return _authService.GenerateJWT(aluno);
    }
}