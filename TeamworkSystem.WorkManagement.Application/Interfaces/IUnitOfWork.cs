using TeamworkSystem.WorkManagement.Application.Interfaces.Repositories;

namespace TeamworkSystem.WorkManagement.Application.Interfaces;

public interface IUnitOfWork
{
    IProjectsRepository ProjectsRepository { get; }
    ITeamsRepository TeamsRepository { get; }
    ITicketsRepository TicketsRepository { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
