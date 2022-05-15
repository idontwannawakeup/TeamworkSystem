using TeamworkSystem.Shared.Interfaces;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.WorkManagement.DataAccess.Entities;
using TeamworkSystem.WorkManagement.DataAccess.Parameters;

namespace TeamworkSystem.WorkManagement.DataAccess.Interfaces.Repositories;

public interface ITeamsRepository : IRepository<Team>
{
    Task<PagedList<Team>> GetAsync(TeamsParameters parameters);
    Task<IEnumerable<Team>> GetUserTeams(UserProfile user);
    Task<IEnumerable<UserProfile>> GetMembersAsync(Guid id);
    Task AddMemberAsync(Guid id, UserProfile member);
    Task DeleteMemberAsync(Guid id, UserProfile member);
}
