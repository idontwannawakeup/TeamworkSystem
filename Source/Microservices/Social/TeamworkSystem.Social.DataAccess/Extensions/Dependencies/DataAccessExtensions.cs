using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TeamworkSystem.Social.DataAccess.Extensions.Dependencies;

public static class DataAccessExtensions
{
    public static IServiceCollection AddDataAccess(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        services.AddData();
        services.AddFilterFactories();
        services.AddSeeding();
        return services;
    }
}
