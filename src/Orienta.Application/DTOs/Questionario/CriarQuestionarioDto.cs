using Orienta.Application.DTOs.Perguntas;
using Orienta.Domain.Enums;

namespace Orienta.Application.DTOs.Questionario
{
    public class CriarQuestionarioDto
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ProfessorSlug { get; set; }
        public List<PerguntaDto> Perguntas { get; set; }
        public QuestionarioFactoryType Tipo { get; set; }
    }
}