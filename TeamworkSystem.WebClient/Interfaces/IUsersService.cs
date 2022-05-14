﻿using Microsoft.AspNetCore.Components.Forms;
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

        Task<IEnumerable<UserViewModel>> GetByTeamIdAsync(Guid teamId);

        Task<UserViewModel> GetByIdAsync(Guid id);

        Task<IEnumerable<UserViewModel>> GetFriendsAsync(Guid id);

        Task<(IEnumerable<UserViewModel>, PaginationHeaderViewModel)> GetFriendsWithPaginationHeaderAsync(
            Guid id,
            UsersParameters parameters);

        Task UpdateAsync(UserViewModel viewModel);

        Task SetAvatarForUserAsync(Guid id, IBrowserFile file);

        Task DeleteAsync(Guid userId);

        Task AddFriendsAsync(FriendsViewModel viewModel);

        Task DeleteFriendsAsync(FriendsViewModel viewModel);
    }
}
