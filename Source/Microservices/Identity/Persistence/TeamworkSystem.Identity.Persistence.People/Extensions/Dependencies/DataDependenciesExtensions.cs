using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Identity.Persistence.People.Data;
using TeamworkSystem.Identity.Persistence.People.Data.Repositories;
using TeamworkSystem.Identity.Persistence.People.Interfaces.Data;
using TeamworkSystem.Identity.Persistence.People.Interfaces.Data.Repositories;

namespace TeamworkSystem.Identity.Persistence.People.Extensions.Dependencies;

public static class DataDependenciesExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddTransient<IUsersRepository, UsersRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
