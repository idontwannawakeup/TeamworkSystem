using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.WorkManagement.Application.Common.Storages;
using TeamworkSystem.WorkManagement.Application.Interfaces.Storages;

namespace TeamworkSystem.WorkManagement.Application.DependencyInjection;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient<IPhotoStorage, PhotoStorage>();
        return services;
    }
}
