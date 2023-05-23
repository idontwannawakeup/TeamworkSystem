using TeamworkSystem.WorkManagement.Application.Interfaces.Data.Repositories;

namespace TeamworkSystem.WorkManagement.Application.Interfaces.Data;

public interface IUnitOfWork
{
    IProjectsRepository ProjectsRepository { get; }
    ITeamsRepository TeamsRepository { get; }
    ITicketsRepository TicketsRepository { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
