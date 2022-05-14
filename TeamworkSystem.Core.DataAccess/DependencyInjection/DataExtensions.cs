using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Core.DataAccess.Data;
using TeamworkSystem.Core.DataAccess.Data.Repositories;
using TeamworkSystem.Core.DataAccess.Interfaces;
using TeamworkSystem.Core.DataAccess.Interfaces.Repositories;

namespace TeamworkSystem.Core.DataAccess.DependencyInjection;

public static class DataExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddTransient<IProjectsRepository, ProjectsRepository>();
        services.AddTransient<ITeamsRepository, TeamsRepository>();
        services.AddTransient<ITicketsRepository, TicketsRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
