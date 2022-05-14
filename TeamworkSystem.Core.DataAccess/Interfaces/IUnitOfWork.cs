using TeamworkSystem.Core.DataAccess.Interfaces.Repositories;

namespace TeamworkSystem.Core.DataAccess.Interfaces;

public interface IUnitOfWork
{
    IProjectsRepository ProjectsRepository { get; }
    ITeamsRepository TeamsRepository { get; }
    ITicketsRepository TicketsRepository { get; }

    Task SaveChangesAsync();
}
