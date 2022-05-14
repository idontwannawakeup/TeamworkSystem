using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Identity.BusinessLogic.Interfaces.Services;
using TeamworkSystem.Identity.BusinessLogic.Services;

namespace TeamworkSystem.Identity.BusinessLogic.DependencyInjection;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<IPhotosService, PhotosService>();
        services.AddTransient<IUsersService, UsersService>();
        return services;
    }
}
