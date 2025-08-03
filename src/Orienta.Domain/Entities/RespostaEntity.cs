namespace Orienta.Domain.Entities;

public class RespostaEntity : BaseEntity
{
    public Guid AlunoId { get; private set; }
    public AlunoEntity Aluno { get; private set; }
    public Guid QuestionarioId { get; private set; }
    public QuestionarioEntity Questionario { get; private set; }
    public List<RespostaPerguntaEntity> RespostasPerguntas { get; private set; }

    private RespostaEntity() { }

    public RespostaEntity(Guid alunoId, Guid questionarioId)
    {
        AlunoId = alunoId;
        QuestionarioId = questionarioId;
    }

    public void AdicionarRespostaPergunta(RespostaPerguntaEntity respostaPergunta)
    {
        RespostasPerguntas.Add(respostaPergunta);
    }
}