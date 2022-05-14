using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Social.BusinessLogic.Interfaces.Services;
using TeamworkSystem.Social.BusinessLogic.Services;

namespace TeamworkSystem.Social.BusinessLogic.DependencyInjection;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<FriendsService>();
        services.AddTransient<IRatingsService, RatingsService>();
        return services;
    }
}
