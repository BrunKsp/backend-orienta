namespace Orienta.Domain.Entities;

public class AlternativaEntity : BaseEntity
{
    public string Texto { get; private set; }
    public bool Correta { get; private set; }
    public Guid PerguntaId { get; private set; }
    public PerguntaEntity Pergunta { get; private set; }
    private AlternativaEntity() { }

    public AlternativaEntity(string texto, bool correta)
    {
        Id = Guid.NewGuid();
        Texto = texto;
        Correta = correta;
    }

    public void VincularPergunta(Guid perguntaId)
    {
        PerguntaId = perguntaId;
    }
}