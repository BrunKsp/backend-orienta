using Microsoft.AspNetCore.Mvc;
using Orienta.Application.UseCases;
using Orienta.Application.UseCases.Questionario;
using Orienta.Domain.Entities;
using Orienta.Domain.Enums;

namespace Orienta.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            return Ok("Questionário criado com sucesso");
        }
    }
}