using Orienta.Application.DTOs.Perguntas;
using Orienta.Domain.Enums;

public class CriarQuestionarioDto
{
    public string Titulo { get; set; } = null!;
    public string? Descricao { get; set; }
    public Guid? ProfessorId { get; set; }
    public List<PerguntaDto> Perguntas { get; set; } = new();
    public QuestionarioFactoryType Tipo { get; set; }
}
