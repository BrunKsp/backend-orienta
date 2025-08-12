using Orienta.Application.DTOs.Perguntas.Alternativas;
using Orienta.Domain.Enums;

namespace Orienta.Application.DTOs.Perguntas
{
    public class PerguntaDto
    {
        public string Enunciado { get; set; }
        public TipoPergunta Tipo { get; set; }
        public List<AlternativaDto> Alternativas { get; set; }
        public string RespostaEsperada { get; set; }
    }
}