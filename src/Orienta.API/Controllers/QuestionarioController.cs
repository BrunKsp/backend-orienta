using Microsoft.AspNetCore.Mvc;
using Orienta.Application.DTOs.Questionario;
using Orienta.Application.UseCases.Questionario;

namespace Orienta.API.Controllers
{
    [ApiController]
    [Route("questionario")]
    public class QuestionarioController : ControllerBase
    {
        private readonly CriarQuestionarioUseCase _useCase;

        public QuestionarioController(CriarQuestionarioUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarQuestionarioDto dto)
        {
            await _useCase.ExecuteAsync(dto);
            return Created();
        }
    }
}