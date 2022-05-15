using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.WorkManagement.DataAccess.Data;
using TeamworkSystem.WorkManagement.DataAccess.Data.Repositories;
using TeamworkSystem.WorkManagement.DataAccess.Interfaces;
using TeamworkSystem.WorkManagement.DataAccess.Interfaces.Repositories;

namespace TeamworkSystem.WorkManagement.DataAccess.DependencyInjection;

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
