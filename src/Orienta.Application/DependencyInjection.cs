using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Orienta.Application.Factories;
using Orienta.Application.Interfaces;
using Orienta.Application.Services;
using Orienta.Application.UseCases.Aluno;
using Orienta.Application.UseCases.Professor;
using Orienta.Application.UseCases.Questionario;

namespace Orienta.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        #region Providers
        services.AddScoped<IQuestionarioFactoryProvider, QuestionarioFactoryProvider>();
        services.AddScoped<IUsuarioFactoryProvider, UsuarioFactoryProvider>();
        #endregion

        #region UseCases
        services.AddScoped<CriarQuestionarioUseCase>();
        services.AddScoped<CriarProfessorUseCase>();
        services.AddScoped<CriarAlunoUseCase>();
        #endregion

        #region Services
        services.AddScoped<IAuthService, AuthService>();
        #endregion

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        return services;
    }
}