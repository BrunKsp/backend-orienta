using Orienta.Application.DTOs.Perguntas.Alternativas;
using Orienta.Domain.Enums;

namespace Orienta.Application.DTOs.Perguntas
{
    public class PerguntaDto
    {
        public string Enunciado { get; private set; }
        public TipoPergunta Tipo { get; private set; }
        public List<AlternativaDto> Alternativas { get; private set; } = new();
        public string RespostaEsperada { get; private set; }
    }
}