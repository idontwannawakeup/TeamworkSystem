using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Social.BusinessLogic.Interfaces.Services;
using TeamworkSystem.Social.BusinessLogic.Services;

namespace TeamworkSystem.Social.BusinessLogic.Extensions.Dependencies;

public static class ServicesDependenciesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IFriendsService, FriendsService>();
        services.AddTransient<IRatingsService, RatingsService>();
        return services;
    }
}
