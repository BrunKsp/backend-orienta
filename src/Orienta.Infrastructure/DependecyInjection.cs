using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orienta.Infrastructure.Factories;
using Orienta.Infrastructure.Persistence;
using Orienta.Infrastructure.Repositories;

namespace Orienta.Infrastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<OrientaDbContext>();
        
        #region Factories
        services.AddScoped<QuestionarioProfessorFactory>();
        services.AddScoped<QuestionarioIAFactory>();
        #endregion

        #region Repositories
        services.AddScoped<IQuestionarioRepository, QuestionarioRepository>();
        #endregion
        
        services.AddDbContext<OrientaDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PG"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        return services;
    }
}