using TeamworkSystem.Core.BusinessLogic.DTO.Requests;
using TeamworkSystem.Core.BusinessLogic.DTO.Responses;
using TeamworkSystem.Core.DataAccess.Parameters;
using TeamworkSystem.Shared.Pagination;

namespace TeamworkSystem.Core.BusinessLogic.Interfaces.Services;

public interface IProjectsService
{
    Task<IEnumerable<ProjectResponse>> GetAsync();
    Task<PagedList<ProjectResponse>> GetAsync(ProjectsParameters parameters);
    Task<IEnumerable<ProjectResponse>> GetTeamProjectsAsync(Guid teamId);
    Task<ProjectResponse> GetByIdAsync(Guid id);
    Task InsertAsync(ProjectRequest request);
    Task UpdateAsync(ProjectRequest request);
    Task DeleteAsync(Guid id);
}
