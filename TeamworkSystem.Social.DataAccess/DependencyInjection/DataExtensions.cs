using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Social.DataAccess.Data;
using TeamworkSystem.Social.DataAccess.Data.Repositories;
using TeamworkSystem.Social.DataAccess.Interfaces;
using TeamworkSystem.Social.DataAccess.Interfaces.Repositories;

namespace TeamworkSystem.Social.DataAccess.DependencyInjection;

public static class DataExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddTransient<IRatingsRepository, RatingsRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
