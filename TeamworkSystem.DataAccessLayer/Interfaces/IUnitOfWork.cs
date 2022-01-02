using Microsoft.AspNetCore.Identity;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;

namespace TeamworkSystem.DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        UserManager<User> UserManager { get; }
        SignInManager<User> SignInManager { get; }
        IProjectsRepository ProjectsRepository { get; }
        IRatingsRepository RatingsRepository { get; }
        ITeamsRepository TeamsRepository { get; }
        ITicketsRepository TicketsRepository { get; }

        Task SaveChangesAsync();
    }
}
