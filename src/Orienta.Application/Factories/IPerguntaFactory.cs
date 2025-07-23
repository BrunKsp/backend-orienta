using Orienta.Domain.Entities;
using Orienta.Domain.Enums;

namespace Orienta.Application.Factories;

public interface IPerguntaFactory
{
    PerguntaEntity Criar(
   Guid questionarioId,
   string enunciado,
   TipoPergunta tipo,
   int ordem,
   List<AlternativaEntity>? alternativas = null,
   string? respostaEsperada = null
);
}