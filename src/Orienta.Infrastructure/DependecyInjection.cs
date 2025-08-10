using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orienta.Domain.Contracts;
using Orienta.Domain.Entities;
using Orienta.Infrastructure.Factories;
using Orienta.Infrastructure.Persistence;
using Orienta.Infrastructure.Repositories;
using Orienta.Infrastructure.Repositories.Interfaces;

namespace Orienta.Infrastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<OrientaDbContext>();

        #region Factories
        services.AddScoped<QuestionarioProfessorFactory>();
        services.AddScoped<QuestionarioIAFactory>();
        services.AddScoped<IUsuarioFactory<ProfessorEntity>, UsuarioProfessorFactory>();
        services.AddScoped<IUsuarioFactory<AlunoEntity>, UsuarioAlunoFactory>();
        #endregion

        #region Repositories
        services.AddScoped<IQuestionarioRepository, QuestionarioRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IProfessorRepository, ProfessorRepository>();
        services.AddScoped<IAlunoRepository, AlunoRepository>();
        #endregion

        services.AddDbContext<OrientaDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PG"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        return services;
    }
}