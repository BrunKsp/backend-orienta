using Microsoft.Extensions.DependencyInjection;

namespace Orienta.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
       
        services.AddScoped<IQuestionarioFactoryProvider, QuestionarioFactoryProvider>();

        return services;
    }
}