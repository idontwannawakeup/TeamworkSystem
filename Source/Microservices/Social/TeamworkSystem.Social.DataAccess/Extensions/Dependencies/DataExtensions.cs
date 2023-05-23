using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Social.DataAccess.Data;
using TeamworkSystem.Social.DataAccess.Data.Repositories;
using TeamworkSystem.Social.DataAccess.Interfaces.Data;
using TeamworkSystem.Social.DataAccess.Interfaces.Data.Repositories;

namespace TeamworkSystem.Social.DataAccess.Extensions.Dependencies;

public static class DataExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddTransient<IFriendsRepository, FriendsRepository>();
        services.AddTransient<IRatingsRepository, RatingsRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
