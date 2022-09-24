using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Identity.Persistence.People.Data;
using TeamworkSystem.Identity.Persistence.People.Interfaces.Data;

namespace TeamworkSystem.Identity.Persistence.People.Extensions.Dependencies;

public static class DataDependenciesExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
