namespace Orienta.Domain.Entities;

public class QuestionarioEntity : BaseEntity
{
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public Guid? ProfessorId { get; private set; }
    public bool Oficial { get; private set; }

    public List<PerguntaEntity> Perguntas { get; private set; } = new();

    private QuestionarioEntity() { }

    public QuestionarioEntity(string titulo, string descricao = null, Guid? professorId = null)
    {
        Id = Guid.NewGuid();
        Titulo = titulo;
        Descricao = descricao;
        ProfessorId = professorId;
        Oficial = professorId == null;
        DataCriacao = DateTime.UtcNow;
    }
    public void AdicionarPergunta(PerguntaEntity pergunta)
    {
        Perguntas.Add(pergunta);
    }
}