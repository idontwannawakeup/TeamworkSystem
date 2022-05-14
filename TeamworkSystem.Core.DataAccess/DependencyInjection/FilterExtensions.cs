using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Core.DataAccess.Entities;
using TeamworkSystem.Shared.Filters;
using TeamworkSystem.Shared.Interfaces.Filters;

namespace TeamworkSystem.Core.DataAccess.DependencyInjection;

public static class FilterExtensions
{
    public static IServiceCollection AddFilterFactories(this IServiceCollection services)
    {
        services.AddTransient<IFilterCriteriaFactory, FilterCriteriaFactory>();
        services.AddTransient<IFilterFactory<Project>, FilterFactory<Project>>();
        services.AddTransient<IFilterFactory<Team>, FilterFactory<Team>>();
        services.AddTransient<IFilterFactory<Ticket>, FilterFactory<Ticket>>();
        return services;
    }
}
