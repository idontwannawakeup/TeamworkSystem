using TeamworkSystem.WorkManagement.DataAccess.Interfaces;
using TeamworkSystem.WorkManagement.DataAccess.Interfaces.Repositories;

namespace TeamworkSystem.WorkManagement.DataAccess.Data;

public class UnitOfWork : IUnitOfWork
{
    protected readonly WorkManagementDbContext DatabaseContext;

    public UnitOfWork(
        WorkManagementDbContext databaseContext,
        IProjectsRepository projectsRepository,
        ITeamsRepository teamsRepository,
        ITicketsRepository ticketsRepository)
    {
        DatabaseContext = databaseContext;
        ProjectsRepository = projectsRepository;
        TeamsRepository = teamsRepository;
        TicketsRepository = ticketsRepository;
    }

    public IProjectsRepository ProjectsRepository { get; }
    public ITeamsRepository TeamsRepository { get; }
    public ITicketsRepository TicketsRepository { get; }

    public async Task SaveChangesAsync() => await DatabaseContext.SaveChangesAsync();
}
