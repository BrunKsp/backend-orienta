using Orienta.Domain.Enums;

namespace Orienta.Domain.Entities;

public class PerguntaEntity : BaseEntity
{
    public Guid QuestionarioId { get; private set; }
    public string Enunciado { get; private set; }
    public TipoPergunta Tipo { get; private set; }
    public List<AlternativaEntity> Alternativas { get; private set; } = new();
    public string RespostaEsperada { get; private set; }

    private PerguntaEntity() { }

    public PerguntaEntity(
        Guid questionarioId,
        string enunciado,
        TipoPergunta tipo,
        List<AlternativaEntity>? alternativas = null,
        string? respostaEsperada = null)
    {
        Id = Guid.NewGuid();
        QuestionarioId = questionarioId;
        Enunciado = enunciado;
        Tipo = tipo;

        if (tipo == TipoPergunta.MultiplaEscolha)
        {
            if (alternativas == null || alternativas.Count < 2)
                throw new ArgumentException("Pergunta de múltipla escolha requer pelo menos 2 alternativas.");
        }

        if (tipo != TipoPergunta.Dissertativa && string.IsNullOrWhiteSpace(respostaEsperada))
            throw new ArgumentException("Pergunta objetiva requer uma resposta esperada.");

        Alternativas = alternativas ?? new List<AlternativaEntity>();
        RespostaEsperada = respostaEsperada;
    }

    public void AdicionarAlternativa(AlternativaEntity alternativa)
    {
        alternativa.VincularPergunta(Id);
        Alternativas.Add(alternativa);
    }
}
