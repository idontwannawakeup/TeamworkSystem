using TeamworkSystem.Core.BusinessLogic.DTO.Requests;
using TeamworkSystem.Core.BusinessLogic.DTO.Responses;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.WorkManagement.DataAccess.Parameters;

namespace TeamworkSystem.Core.BusinessLogic.Interfaces.Services;

public interface ITeamsService
{
    Task<IEnumerable<TeamResponse>> GetAsync();
    Task<PagedList<TeamResponse>> GetAsync(TeamsParameters parameters);
    Task<IEnumerable<TeamResponse>> GetUserTeamsAsync(Guid userId);
    Task<TeamResponse> GetByIdAsync(Guid id);
    Task InsertAsync(TeamRequest request);
    Task UpdateAsync(TeamRequest request);
    Task SetAvatarForTeamAsync(TeamAvatarRequest request);
    Task DeleteAsync(Guid id);
    Task AddMemberAsync(TeamMemberRequest request);
    Task DeleteMemberAsync(TeamMemberRequest request);
}
