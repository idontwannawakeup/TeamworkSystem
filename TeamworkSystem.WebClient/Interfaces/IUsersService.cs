using Microsoft.AspNetCore.Components.Forms;
using TeamworkSystem.WebClient.Parameters;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<UserViewModel>> GetAsync(UsersParameters parameters);

        Task<(IEnumerable<UserViewModel>, PaginationHeaderViewModel)> GetWithPaginationHeaderAsync(
            UsersParameters parameters);

        Task<IEnumerable<UserViewModel>> GetAsync();

        Task<IEnumerable<UserViewModel>> GetByTeamIdAsync(int teamId);

        Task<UserViewModel> GetByIdAsync(string id);

        Task<IEnumerable<UserViewModel>> GetFriendsAsync(string id);

        Task<(IEnumerable<UserViewModel>, PaginationHeaderViewModel)> GetFriendsWithPaginationHeaderAsync(
            string id,
            UsersParameters parameters);

        Task UpdateAsync(UserViewModel viewModel);

        Task SetAvatarForUserAsync(string id, IBrowserFile file);

        Task DeleteAsync(string userId);

        Task AddFriendsAsync(FriendsViewModel viewModel);

        Task DeleteFriendsAsync(FriendsViewModel viewModel);
    }
}
