using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Identity.Persistence.People.Data;
using TeamworkSystem.Identity.Persistence.People.Interfaces;

namespace TeamworkSystem.Identity.Persistence.People.DependencyInjection;

public static class DataExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
