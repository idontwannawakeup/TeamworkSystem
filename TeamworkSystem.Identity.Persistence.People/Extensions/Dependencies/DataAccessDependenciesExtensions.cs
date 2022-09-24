using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TeamworkSystem.Identity.Persistence.People.Extensions.Dependencies;

public static class DataAccessDependenciesExtensions
{
    public static IServiceCollection AddDataAccess(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        services.AddData();
        services.AddFilterFactories();
        return services;
    }
}
