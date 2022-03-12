using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Core.BusinessLogic.Interfaces.Services;
using TeamworkSystem.Core.BusinessLogic.Services;

namespace TeamworkSystem.Core.BusinessLogic.DependencyInjection;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IPhotosService, PhotosService>();
        services.AddTransient<IProjectsService, ProjectsService>();
        services.AddTransient<ITeamsService, TeamsService>();
        services.AddTransient<ITicketsService, TicketsService>();
        return services;
    }
}
