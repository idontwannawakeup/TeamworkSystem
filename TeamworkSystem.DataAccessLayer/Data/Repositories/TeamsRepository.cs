using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Exceptions;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Data.Repositories
{
    public class TeamsRepository
        : GenericRepository<Team>, ITeamsRepository
    {
        public async Task<IEnumerable<Team>> GetUserTeams(User user)
        {
            return await this.table
                .Where(team => team.Members.Contains(user))
                .ToListAsync();
        }

        public async Task<PagedList<Team>> GetPageOfUserTeamsAsync(
            User user,
            PaginationParameters parameters)
        {
            return await PagedList<Team>.ToPagedListAsync(
                this.table,
                parameters.PageNumber,
                parameters.PageSize,
                team => team.Members.Contains(user));
        }

        public async Task<Team> GetCompleteTeamAsync(int id)
        {
            return await this.table
                .Include(team => team.Leader)
                .Include(team => team.Projects)
                .Include(team => team.Members)
                .SingleOrDefaultAsync(team => team.Id == id)
                    ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }

        public async Task<IEnumerable<User>> GetMembersAsync(int id)
        {
            Team team = await this.table
                .Include(team => team.Members)
                .SingleOrDefaultAsync(team => team.Id == id)
                    ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));

            return team?.Members;
        }

        public async Task AddMemberAsync(int id, User member)
        {
            Team team = await this.table
                .Include(team => team.Members)
                .SingleOrDefaultAsync(team => team.Id == id)
                    ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));

            team?.Members?.Add(member);
        }

        public async Task DeleteMemberAsync(int id, User member)
        {
            Team team = await this.table
                .Include(team => team.Members)
                .SingleOrDefaultAsync(team => team.Id == id)
                    ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));

            team?.Members?.Remove(member);
        }

        public TeamsRepository(TeamworkSystemContext databaseContext)
            : base(databaseContext)
        {
        }
    }
}
