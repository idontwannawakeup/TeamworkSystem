using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Identity.People.BusinessLogic.Interfaces.Services;
using TeamworkSystem.Identity.People.BusinessLogic.Services;

namespace TeamworkSystem.Identity.People.BusinessLogic.Extensions.Dependencies;

public static class ServicesDependenciesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IPhotosService, PhotosService>();
        services.AddTransient<IUsersService, UsersService>();
        return services;
    }
}
