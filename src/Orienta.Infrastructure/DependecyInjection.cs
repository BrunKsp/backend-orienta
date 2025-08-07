using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        services.AddScoped<UsuarioAlunoFactory>();
        services.AddScoped<UsuarioProfessorFactory>();
        #endregion

        #region Repositories
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        #endregion

        services.AddDbContext<OrientaDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PG"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        return services;
    }
}