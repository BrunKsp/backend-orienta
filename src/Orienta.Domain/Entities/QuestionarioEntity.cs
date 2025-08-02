using Orienta.Domain.Enums;

namespace Orienta.Domain.Entities;

public class QuestionarioEntity : BaseEntity
{
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public string ProfessorSlug { get; private set; }
    public QuestionarioFactoryType CriadoPor { get; private set; }
    public List<PerguntaEntity> Perguntas { get; private set; }

    private QuestionarioEntity() { }

    public QuestionarioEntity(string titulo, string descricao, string professorSlug, QuestionarioFactoryType criadoPor, List<PerguntaEntity> perguntas)
    {
        Titulo = titulo;
        Descricao = descricao;
        ProfessorSlug = professorSlug;
        CriadoPor = criadoPor;
        Perguntas = perguntas;
    }

    public void AdicionarPergunta(PerguntaEntity pergunta)
    {
        pergunta.VincularQuestionario(Id);
        Perguntas.Add(pergunta);
    }
}