using Microsoft.AspNetCore.Mvc;
using Orienta.Application.UseCases;
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
            var perguntas = dto.Perguntas.Select(p =>
                new PerguntaEntity(p.Texto, (TipoPergunta)p.Tipo)
            ).ToList();

            await _useCase.ExecuteAsync(dto.Titulo, dto.Descricao, dto.ProfessorId, perguntas, dto.Tipo);
            return Ok("Questionário criado com sucesso");
        }
    }
}