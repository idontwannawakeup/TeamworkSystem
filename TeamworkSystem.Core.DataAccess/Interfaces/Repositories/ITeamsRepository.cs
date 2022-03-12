using TeamworkSystem.Core.DataAccess.Entities;
using TeamworkSystem.Core.DataAccess.Parameters;
using TeamworkSystem.Shared.Pagination;

namespace TeamworkSystem.Core.DataAccess.Interfaces.Repositories;

public interface ITeamsRepository : IRepository<Team>
{
    Task<PagedList<Team>> GetAsync(TeamsParameters parameters);
    Task<IEnumerable<Team>> GetUserTeams(UserProfile user);
    Task<IEnumerable<UserProfile>> GetMembersAsync(int id);
    Task AddMemberAsync(int id, UserProfile member);
    Task DeleteMemberAsync(int id, UserProfile member);
}
