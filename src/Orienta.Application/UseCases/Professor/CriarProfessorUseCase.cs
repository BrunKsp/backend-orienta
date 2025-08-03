using Orienta.Application.DTOs.Professor;
using Orienta.Application.Exceptions;
using Orienta.Domain.Entities;
using Orienta.Infrastructure.Repositories.Interfaces;

namespace Orienta.Application.UseCases.Professor;

public class CriarProfessorUseCase
{
    private readonly IProfessorRepository _repository;

    public CriarProfessorUseCase(IProfessorRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(CriarProfessorDto dto)
    {
        var jaExiste = await _repository.ObterPorEmailAsync(dto.Email);
        if (jaExiste is not null)
            throw CustomException.ErroValidacao(new { error = "Já existe esse email!" });

        var professor = new ProfessorEntity(dto.Nome, dto.Sobrenome,null, dto.Email);
        await _repository.Criar(professor);
    }
}