using TeamworkSystem.WebClient.Parameters;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Interfaces;

public interface IProjectsService
{
    Task<IEnumerable<ProjectViewModel>> GetAsync(ProjectsParameters parameters);

    Task<(IEnumerable<ProjectViewModel>, PaginationHeaderViewModel)> GetWithPaginationHeaderAsync(
        ProjectsParameters parameters);

    Task<IEnumerable<ProjectViewModel>> GetByTeamIdAsync(Guid teamId);

    Task<IEnumerable<ProjectViewModel>> GetProjectsForTeamMemberAsync(Guid teamMemberId);

    Task<ProjectViewModel> GetByIdAsync(Guid id);

    Task CreateAsync(ProjectViewModel viewModel);

    Task UpdateAsync(ProjectViewModel viewModel);

    Task DeleteAsync(Guid id);
}
