using Microsoft.AspNetCore.Mvc;
using Orienta.Application.DTOs.Professor;
using Orienta.Application.DTOs.Usuario;
using Orienta.Application.UseCases.Professor;

namespace Orienta.API.Controllers
{
    [Route("professor")]
    public class ProfessorController : ControllerBase
    {
        private readonly CriarProfessorUseCase _useCase;
        private readonly BuscarProfessorUseCase _buscarUseCase;
        public ProfessorController(CriarProfessorUseCase useCase, BuscarProfessorUseCase buscarUseCase)
        {
            _useCase = useCase;
            _buscarUseCase = buscarUseCase;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UsuarioAutenticadoDto), StatusCodes.Status201Created)]
        public async Task<ActionResult<UsuarioAutenticadoDto>> Criar([FromBody] CriarProfessorDto dto)
        {
            return StatusCode(StatusCodes.Status201Created, await _useCase.ExecuteAsync(dto));
        }

        [HttpGet]
        public async Task<UsuarioAutenticadoDto> BuscarDados()
        {
            return await _buscarUseCase.ExecuteAsync();
        }
    }
}