using TeamworkSystem.WorkManagement.Application.Interfaces.Data;
using TeamworkSystem.WorkManagement.Application.Interfaces.Data.Repositories;

namespace TeamworkSystem.WorkManagement.Persistence.Data;

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

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await DatabaseContext.SaveChangesAsync(cancellationToken);
}
