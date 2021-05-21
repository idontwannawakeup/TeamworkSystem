using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<UserViewModel>> GetAsync();

        Task<IEnumerable<UserViewModel>> GetByTeamIdAsync(int teamId);

        Task<UserViewModel> GetByIdAsync(string id);

        Task<IEnumerable<UserViewModel>> GetFriendsAsync(string id);

        Task UpdateAsync(UserViewModel viewModel);

        Task DeleteAsync(string userId);

        Task AddFriendsAsync(FriendsViewModel viewModel);

        Task DeleteFriendsAsync(FriendsViewModel viewModel);
    }
}
