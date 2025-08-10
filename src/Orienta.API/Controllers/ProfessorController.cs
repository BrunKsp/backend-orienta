using Microsoft.AspNetCore.Mvc;
using Orienta.Application.DTOs.Professor;
using Orienta.Application.DTOs.Usuario;
using Orienta.Application.UseCases.Professor;

namespace Orienta.API.Controllers
{
    [Route("[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly CriarProfessorUseCase _useCase;
        public ProfessorController(CriarProfessorUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost]
        public async Task<UsuarioAutenticadoDto> Post([FromBody] CriarProfessorDto dto)
        {
            return await _useCase.ExecuteAsync(dto);
        }
    }
}