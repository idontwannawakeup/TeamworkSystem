using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Core.DataAccess.Interfaces.Seeders;
using TeamworkSystem.Core.DataAccess.Seeders;

namespace TeamworkSystem.Core.DataAccess.DependencyInjection;

public static class SeedingExtensions
{
    public static IServiceCollection AddSeeding(this IServiceCollection services)
    {
        services.AddTransient<IUserProfileSeeder, UserProfileSeeder>();
        services.AddTransient<IProjectSeeder, ProjectSeeder>();
        services.AddTransient<ITeamSeeder, TeamSeeder>();
        services.AddTransient<ITeamsMembersSeeder, TeamsMembersSeeder>();
        services.AddTransient<ITicketSeeder, TicketSeeder>();
        return services;
    }
}
