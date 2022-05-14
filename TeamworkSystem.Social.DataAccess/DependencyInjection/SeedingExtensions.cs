using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Social.DataAccess.Interfaces.Seeders;
using TeamworkSystem.Social.DataAccess.Seeders;

namespace TeamworkSystem.Social.DataAccess.DependencyInjection;

public static class SeedingExtensions
{
    public static IServiceCollection AddSeeding(this IServiceCollection services)
    {
        services.AddTransient<IRatingSeeder, RatingSeeder>();
        services.AddTransient<IUserProfileSeeder, UserProfileSeeder>();
        return services;
    }
}
