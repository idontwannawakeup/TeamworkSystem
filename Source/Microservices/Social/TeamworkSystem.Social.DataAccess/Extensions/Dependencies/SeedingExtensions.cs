using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Social.DataAccess.Data.Seeders;
using TeamworkSystem.Social.DataAccess.Interfaces.Data.Seeders;

namespace TeamworkSystem.Social.DataAccess.Extensions.Dependencies;

public static class SeedingExtensions
{
    public static IServiceCollection AddSeeding(this IServiceCollection services)
    {
        services.AddTransient<IRatingSeeder, RatingSeeder>();
        services.AddTransient<IUserProfileSeeder, UserProfileSeeder>();
        return services;
    }
}
