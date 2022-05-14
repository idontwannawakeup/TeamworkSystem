using TeamworkSystem.Core.DataAccess.Interfaces;
using TeamworkSystem.Core.DataAccess.Interfaces.Repositories;

namespace TeamworkSystem.Core.DataAccess.Data;

public class UnitOfWork : IUnitOfWork
{
    protected readonly TeamworkSystemCoreDbContext DatabaseContext;

    public UnitOfWork(
        TeamworkSystemCoreDbContext databaseContext,
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
