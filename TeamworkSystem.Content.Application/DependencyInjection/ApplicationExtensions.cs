using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace TeamworkSystem.Content.Application.DependencyInjection;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}
