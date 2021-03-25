using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;

namespace TeamworkSystem.DataAccessLayer.Data.Repositories
{
    public class TeamsRepository
        : GenericRepository<Team>, ITeamsRepository
    {
        public async Task<Team> GetCompleteTeamAsync(int id)
        {
            return await this.table
                .Include(team => team.Leader)
                .Include(team => team.Projects)
                .Include(team => team.Members)
                .SingleOrDefaultAsync(team => team.Id == id);
        }

        public async Task<IEnumerable<User>> GetMembersAsync(int id)
        {
            Team team = await this.table
                .Include(team => team.Members)
                .SingleOrDefaultAsync(team => team.Id == id);

            return team?.Members ?? throw new Exception($"{typeof(Team).Name} not found.");
        }

        public async Task AddMemberAsync(int id, User member)
        {
            Team team = await this.table
                .Include(team => team.Members)
                .SingleOrDefaultAsync(team => team.Id == id);

            team?.Members.Add(member);
        }

        public async Task DeleteMemberAsync(int id, User member)
        {
            Team team = await this.table
                .Include(team => team.Members)
                .FirstOrDefaultAsync(team => team.Id == id);

            team?.Members.Remove(member);
        }

        public TeamsRepository(TeamworkSystemContext databaseContext)
            : base(databaseContext)
        {
        }
    }
}
