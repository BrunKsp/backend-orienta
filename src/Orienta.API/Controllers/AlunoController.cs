using Microsoft.AspNetCore.Mvc;
using Orienta.Application.DTOs.Aluno;
using Orienta.Application.DTOs.Usuario;
using Orienta.Application.UseCases.Aluno;

namespace Orienta.API.Controllers
{
    [Route("aluno")]
    public class AlunoController : Controller
    {
        private readonly CriarAlunoUseCase _useCase;
        public AlunoController(CriarAlunoUseCase useCase)
        {
            _useCase = useCase;
        }
        [HttpPost]
        public async Task<UsuarioAutenticadoDto> Criar([FromBody] CriarAlunoDto dto)
        {
            return await _useCase.ExecuteAsync(dto);
        }
    }
}