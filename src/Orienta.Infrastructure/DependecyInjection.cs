using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orienta.Infrastructure.Persistence;

namespace Orienta.Infrastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {

        services.AddDbContext<OrientaDbContext>(options =>
           options.UseNpgsql(IConfiguration.GetConnectionString("DefaultConnection")));
           
        return services;
    }
}