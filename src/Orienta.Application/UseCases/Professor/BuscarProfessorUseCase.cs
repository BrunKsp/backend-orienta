using Orienta.Application.DTOs.Usuario;
using Orienta.Application.Services;
using Orienta.Application.Utils;
using Orienta.Infrastructure.Repositories.Interfaces;

namespace Orienta.Application.UseCases.Professor;

public class BuscarProfessorUseCase : BaseService
{
    private readonly IProfessorRepository _repository;
    private readonly IUserInfo _userInfo;
    public BuscarProfessorUseCase(IProfessorRepository repository, IUserInfo userInfo) : base(userInfo)
    {
        _repository = repository;
        _userInfo = userInfo;
    }

    public async Task<UsuarioAutenticadoDto> ExecuteAsync()
    {
        var slug = GetUserSlug();
        var professor = await _repository.BuscarPorSlug(slug);
        return new UsuarioAutenticadoDto
        {
            Slug = professor.Slug,
            Nome = professor.Nome,
            Email = professor.Email,
            Foto = professor.Foto,
            TipoUsuario = professor.TipoUsuario,

        };
    }
}