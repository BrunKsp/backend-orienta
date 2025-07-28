using Microsoft.Extensions.DependencyInjection;
using Orienta.Application.UseCases.Questionario;

namespace Orienta.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddScoped<IQuestionarioFactoryProvider, QuestionarioFactoryProvider>();
        services.AddScoped<CriarQuestionarioUseCase>();
        return services;
    }
}