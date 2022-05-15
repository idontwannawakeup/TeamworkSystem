using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Shared.Filters;
using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.WorkManagement.DataAccess.Entities;

namespace TeamworkSystem.WorkManagement.DataAccess.DependencyInjection;

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
