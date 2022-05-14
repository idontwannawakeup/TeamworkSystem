using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Identity.DataAccess.Data;
using TeamworkSystem.Identity.DataAccess.Interfaces;

namespace TeamworkSystem.Identity.DataAccess.DependencyInjection;

public static class DataExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
