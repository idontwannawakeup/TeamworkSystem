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

        Task<IEnumerable<TeamViewModel>> GetTeamsForUserAsync(string userId);

        Task<TeamViewModel> GetByIdAsync(int id);

        Task CreateAsync(TeamViewModel viewModel);

        Task UpdateAsync(TeamViewModel viewModel);

        Task SetAvatarForTeamAsync(int id, IBrowserFile file);

        Task DeleteAsync(int id);

        Task AddMemberAsync(TeamMemberViewModel viewModel);

        Task DeleteMemberAsync(TeamMemberViewModel viewModel);
    }
}
