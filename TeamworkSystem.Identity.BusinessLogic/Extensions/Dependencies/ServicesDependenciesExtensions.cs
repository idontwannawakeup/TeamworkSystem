using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Identity.BusinessLogic.Interfaces.Services;
using TeamworkSystem.Identity.BusinessLogic.Services;

namespace TeamworkSystem.Identity.BusinessLogic.Extensions.Dependencies;

public static class ServicesDependenciesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IPhotosService, PhotosService>();
        services.AddTransient<IUsersService, UsersService>();
        return services;
    }
}
