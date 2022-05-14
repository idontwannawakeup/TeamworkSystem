using Microsoft.AspNetCore.Components.Forms;
using TeamworkSystem.WebClient.Parameters;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Interfaces
{
    public interface ITeamsService
    {
        Task<IEnumerable<TeamViewModel>> GetAsync(TeamsParameters parameters);

        Task<(IEnumerable<TeamViewModel>, PaginationHeaderViewModel)> GetWithPaginationHeaderAsync(
            TeamsParameters parameters);

        Task<IEnumerable<TeamViewModel>> GetTeamsForUserAsync(Guid userId);

        Task<TeamViewModel> GetByIdAsync(Guid id);

        Task CreateAsync(TeamViewModel viewModel);

        Task UpdateAsync(TeamViewModel viewModel);

        Task SetAvatarForTeamAsync(Guid id, IBrowserFile file);

        Task DeleteAsync(Guid id);

        Task AddMemberAsync(TeamMemberViewModel viewModel);

        Task DeleteMemberAsync(TeamMemberViewModel viewModel);
    }
}
