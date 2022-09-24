using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.WorkManagement.Application.Common.Storages;
using TeamworkSystem.WorkManagement.Application.Interfaces.Data.Storages;
using TeamworkSystem.WorkManagement.Application.Interfaces.Services;
using TeamworkSystem.WorkManagement.Application.Services;

namespace TeamworkSystem.WorkManagement.Application.Extensions.Dependencies;

public static class ApplicationDependenciesExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient<IPhotoStorage, PhotoStorage>();

        services.AddTransient<IProjectsService, ProjectsService>();
        services.AddTransient<ITicketsService, TicketsService>();

        return services;
    }
}
