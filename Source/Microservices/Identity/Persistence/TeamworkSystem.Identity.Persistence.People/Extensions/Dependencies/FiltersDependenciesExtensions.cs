using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Identity.Persistence.People.Data.Entities;
using TeamworkSystem.Shared.Filters;
using TeamworkSystem.Shared.Interfaces.Filters;

namespace TeamworkSystem.Identity.Persistence.People.Extensions.Dependencies;

public static class FiltersDependenciesExtensions
{
    public static IServiceCollection AddFilterFactories(this IServiceCollection services)
    {
        services.AddTransient<IFilterCriteriaFactory, FilterCriteriaFactory>();
        services.AddTransient<IFilterFactory<User>, FilterFactory<User>>();
        return services;
    }
}
