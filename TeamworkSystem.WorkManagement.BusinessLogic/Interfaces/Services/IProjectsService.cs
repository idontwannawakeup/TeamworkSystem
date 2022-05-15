using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.WorkManagement.BusinessLogic.DTO.Requests;
using TeamworkSystem.WorkManagement.BusinessLogic.DTO.Responses;
using TeamworkSystem.WorkManagement.DataAccess.Parameters;

namespace TeamworkSystem.WorkManagement.BusinessLogic.Interfaces.Services;

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
