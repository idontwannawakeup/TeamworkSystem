﻿using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Shared.Filters;
using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.Social.DataAccess.Entities;

namespace TeamworkSystem.Social.DataAccess.DependencyInjection;

public static class FilterExtensions
{
    public static IServiceCollection AddFilterFactories(this IServiceCollection services)
    {
        services.AddTransient<IFilterCriteriaFactory, FilterCriteriaFactory>();
        services.AddTransient<IFilterFactory<Rating>, FilterFactory<Rating>>();
        return services;
    }
}
