namespace Orienta.Domain.Entities;

public class QuestionarioEntity : BaseEntity
{
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public Guid? ProfessorId { get; private set; }
    public List<PerguntaEntity> Perguntas { get; private set; }

    public QuestionarioEntity(string titulo, string descricao, Guid? professorId, List<PerguntaEntity> perguntas)
    {
        Titulo = titulo;
        Descricao = descricao;
        ProfessorId = professorId;
        Perguntas = perguntas;
    }
}