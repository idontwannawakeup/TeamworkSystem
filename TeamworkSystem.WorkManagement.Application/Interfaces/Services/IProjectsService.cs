using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.WorkManagement.Application.Common.Requests;
using TeamworkSystem.WorkManagement.Application.Common.Responses;
using TeamworkSystem.WorkManagement.Domain.Parameters;

namespace TeamworkSystem.WorkManagement.Application.Interfaces.Services;

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
