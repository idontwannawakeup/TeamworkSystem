using TeamworkSystem.Core.BusinessLogic.DTO.Requests;
using TeamworkSystem.Core.BusinessLogic.DTO.Responses;
using TeamworkSystem.Core.DataAccess.Parameters;
using TeamworkSystem.Shared.Pagination;

namespace TeamworkSystem.Core.BusinessLogic.Interfaces.Services;

public interface ITeamsService
{
    Task<IEnumerable<TeamResponse>> GetAsync();
    Task<PagedList<TeamResponse>> GetAsync(TeamsParameters parameters);
    Task<IEnumerable<TeamResponse>> GetUserTeamsAsync(string userId);
    Task<TeamResponse> GetByIdAsync(int id);
    Task InsertAsync(TeamRequest request);
    Task UpdateAsync(TeamRequest request);
    Task SetAvatarForTeamAsync(TeamAvatarRequest request);
    Task DeleteAsync(int id);
    Task AddMemberAsync(TeamMemberRequest request);
    Task DeleteMemberAsync(TeamMemberRequest request);
}
