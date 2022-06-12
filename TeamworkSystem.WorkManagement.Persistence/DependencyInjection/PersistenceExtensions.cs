using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Shared.Filters;
using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.WorkManagement.Application.Interfaces;
using TeamworkSystem.WorkManagement.Application.Interfaces.Repositories;
using TeamworkSystem.WorkManagement.Application.Interfaces.Seeders;
using TeamworkSystem.WorkManagement.Domain.Entities;
using TeamworkSystem.WorkManagement.Persistence.Data;
using TeamworkSystem.WorkManagement.Persistence.Data.Repositories;
using TeamworkSystem.WorkManagement.Persistence.Seeders;

namespace TeamworkSystem.WorkManagement.Persistence.DependencyInjection;

public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<WorkManagementDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        });

        services.AddTransient<IProjectsRepository, ProjectsRepository>();
        services.AddTransient<ITeamsRepository, TeamsRepository>();
        services.AddTransient<ITicketsRepository, TicketsRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        services.AddTransient<IFilterCriteriaFactory, FilterCriteriaFactory>();
        services.AddTransient<IFilterFactory<Project>, FilterFactory<Project>>();
        services.AddTransient<IFilterFactory<Team>, FilterFactory<Team>>();
        services.AddTransient<IFilterFactory<Ticket>, FilterFactory<Ticket>>();

        services.AddTransient<IUserProfileSeeder, UserProfileSeeder>();
        services.AddTransient<IProjectSeeder, ProjectSeeder>();
        services.AddTransient<ITeamSeeder, TeamSeeder>();
        services.AddTransient<ITeamsMembersSeeder, TeamsMembersSeeder>();
        services.AddTransient<ITicketSeeder, TicketSeeder>();

        return services;
    }
}
