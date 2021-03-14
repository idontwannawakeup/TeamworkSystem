﻿using System.Threading.Tasks;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;

namespace TeamworkSystem.DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IUsersRepository UsersRepository { get; }

        ITeamsRepository TeamsRepository { get; }

        IProjectsRepository ProjectsRepository { get; }

        ITicketsRepository TicketsRepository { get; }

        IRatingsRepository RatingsRepository { get; }

        Task SaveChangesAsync();
    }
}
