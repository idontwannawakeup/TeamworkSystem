using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Identity.DataAccess.Interfaces.Seeders;
using TeamworkSystem.Identity.DataAccess.Seeders;

namespace TeamworkSystem.Identity.DataAccess.DependencyInjection;

public static class SeedingExtensions
{
    public static IServiceCollection AddSeeding(this IServiceCollection services)
    {
        services.AddTransient<IUserSeeder, UserSeeder>();
        return services;
    }
}
