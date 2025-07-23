using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orienta.Infrastructure.Persistence;

namespace Orienta.Infrastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<OrientaDbContext>();

        services.AddDbContext<OrientaDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PG"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        return services;
    }
}