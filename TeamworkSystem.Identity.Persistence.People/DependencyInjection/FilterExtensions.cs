using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Identity.Persistence.People.Entities;
using TeamworkSystem.Shared.Filters;
using TeamworkSystem.Shared.Interfaces.Filters;

namespace TeamworkSystem.Identity.Persistence.People.DependencyInjection;

public static class FilterExtensions
{
    public static IServiceCollection AddFilterFactories(this IServiceCollection services)
    {
        services.AddTransient<IFilterCriteriaFactory, FilterCriteriaFactory>();
        services.AddTransient<IFilterFactory<User>, FilterFactory<User>>();
        return services;
    }
}
