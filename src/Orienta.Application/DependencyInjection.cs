using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Orienta.Application.Factories;
using Orienta.Application.Interfaces;
using Orienta.Application.Services;
using Orienta.Application.UseCases.Professor;
using Orienta.Application.UseCases.Questionario;

namespace Orienta.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddScoped<IQuestionarioFactoryProvider, QuestionarioFactoryProvider>();
        services.AddScoped<CriarQuestionarioUseCase>();
        services.AddScoped<CriarProfessorUseCase>();
        services.AddScoped<IUsuarioFactoryProvider, UsuarioFactoryProvider>();

        services.AddScoped<IAuthService, AuthService>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        return services;
    }
}