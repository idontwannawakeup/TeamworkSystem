﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Interfaces.Repositories
{
    public interface ITeamsRepository : IRepository<Team>
    {
        Task<PagedList<Team>> GetAsync(TeamsParameters parameters);

        Task<IEnumerable<Team>> GetUserTeams(User user);

        Task<IEnumerable<User>> GetMembersAsync(int id);

        Task AddMemberAsync(int id, User member);

        Task DeleteMemberAsync(int id, User member);
    }
}
