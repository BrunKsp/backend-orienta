using Orienta.Domain.Enums;

namespace Orienta.Application.DTOs.Questionario;

public class CriarQuestionarioDto
{
    public string Titulo { get; set; }
    public string? Descricao { get; set; }
    public Guid? ProfessorId { get; set; }
    public List<PerguntaCriacaoDto> Perguntas { get; set; } = new();
}

public class PerguntaCriacaoDto
{
    public string Enunciado { get; set; }
    public TipoPergunta Tipo { get; set; }
    public int Ordem { get; set; }
    public List<AlternativaCriacaoDto>? Alternativas { get; set; }
    public string? RespostaEsperada { get; set; }
}

public class AlternativaCriacaoDto
{
    public string Texto { get; set; }
    public bool Correta { get; set; }
}
