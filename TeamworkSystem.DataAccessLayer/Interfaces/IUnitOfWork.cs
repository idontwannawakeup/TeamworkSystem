using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;

namespace TeamworkSystem.DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        UserManager<User> UserManager { get; }

        ITeamsRepository TeamsRepository { get; }

        IProjectsRepository ProjectsRepository { get; }

        ITicketsRepository TicketsRepository { get; }

        IRatingsRepository RatingsRepository { get; }

        Task SaveChangesAsync();
    }
}
