using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Interfaces
{
    public interface ITeamsService
    {
        Task<IEnumerable<TeamViewModel>> GetTeamsForUserAsync(string userId);

        Task<TeamViewModel> GetByIdAsync(int id);

        Task CreateAsync(TeamViewModel viewModel);

        Task UpdateAsync(TeamViewModel viewModel);

        Task DeleteAsync(int id);

        Task AddMemberAsync(TeamMemberViewModel viewModel);

        Task DeleteMemberAsync(TeamMemberViewModel viewModel);
    }
}
