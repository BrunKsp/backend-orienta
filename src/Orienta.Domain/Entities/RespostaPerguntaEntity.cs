namespace Orienta.Domain.Entities;

public class RespostaPerguntaEntity : BaseEntity
{
    public Guid RespostaId { get; private set; }
    public RespostaEntity Resposta { get; private set; } = null!;

    public Guid PerguntaId { get; private set; }
    public PerguntaEntity Pergunta { get; private set; } = null!;

    public string RespostaAluno { get; private set; }

    protected  RespostaPerguntaEntity() { }

    public RespostaPerguntaEntity(Guid respostaId, Guid perguntaId, string respostaAluno)
    {
        RespostaId = respostaId;
        PerguntaId = perguntaId;
        RespostaAluno = respostaAluno;
    }
}