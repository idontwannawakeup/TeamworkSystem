using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.WorkManagement.BusinessLogic.Interfaces.Services;
using TeamworkSystem.WorkManagement.BusinessLogic.Services;

namespace TeamworkSystem.WorkManagement.BusinessLogic.DependencyInjection;

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
