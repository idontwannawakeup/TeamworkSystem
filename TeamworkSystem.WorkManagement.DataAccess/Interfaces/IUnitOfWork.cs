using TeamworkSystem.WorkManagement.DataAccess.Interfaces.Repositories;

namespace TeamworkSystem.WorkManagement.DataAccess.Interfaces;

public interface IUnitOfWork
{
    IProjectsRepository ProjectsRepository { get; }
    ITeamsRepository TeamsRepository { get; }
    ITicketsRepository TicketsRepository { get; }

    Task SaveChangesAsync();
}
