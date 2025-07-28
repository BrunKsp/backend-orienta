using Microsoft.Extensions.DependencyInjection;
using Orienta.Domain.Contracts;
using Orienta.Domain.Enums;
using Orienta.Infrastructure.Factories;

public interface IQuestionarioFactoryProvider
{
    IQuestionarioFactory Resolver(QuestionarioFactoryType tipo);
}

public class QuestionarioFactoryProvider : IQuestionarioFactoryProvider
{
    private readonly IServiceProvider _provider;

    public QuestionarioFactoryProvider(IServiceProvider provider)
    {
        _provider = provider;
    }

    public IQuestionarioFactory Resolver(QuestionarioFactoryType tipo)
    {
        return tipo switch
        {
            QuestionarioFactoryType.Professor => _provider.GetRequiredService<QuestionarioProfessorFactory>(),
            QuestionarioFactoryType.IA => _provider.GetRequiredService<QuestionarioIAFactory>(),
            _ => throw new NotImplementedException()
        };
    }
}
