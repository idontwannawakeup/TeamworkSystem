using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Identity.Persistence.People.Interfaces.Seeders;
using TeamworkSystem.Identity.Persistence.People.Seeders;

namespace TeamworkSystem.Identity.Persistence.People.DependencyInjection;

public static class SeedingExtensions
{
    public static IServiceCollection AddSeeding(this IServiceCollection services)
    {
        services.AddTransient<IUserSeeder, UserSeeder>();
        return services;
    }
}
