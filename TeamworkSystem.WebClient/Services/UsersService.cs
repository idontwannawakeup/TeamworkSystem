using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TeamworkSystem.WebClient.Extensions;
using TeamworkSystem.WebClient.Interfaces;
using TeamworkSystem.WebClient.Parameters;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApiHttpClient httpClient;

        public async Task<IEnumerable<UserViewModel>> GetAsync(UsersParameters parameters) =>
            await httpClient.GetAsync<List<UserViewModel>>(
                ParametersStringFactory.GenerateParametersString(parameters));

        public async Task<(IEnumerable<UserViewModel>, PaginationHeaderViewModel)> GetWithPaginationHeaderAsync(
            UsersParameters parameters)
        {
            return await httpClient.GetWithPaginationHeaderAsync<List<UserViewModel>>(
                ParametersStringFactory.GenerateParametersString(parameters));
        }

        public async Task<IEnumerable<UserViewModel>> GetAsync() =>
            await httpClient.GetAsync<List<UserViewModel>>(string.Empty);

        public async Task<IEnumerable<UserViewModel>> GetByTeamIdAsync(int teamId) =>
            await httpClient.GetAsync<List<UserViewModel>>($"?TeamId={teamId}");

        public async Task<UserViewModel> GetByIdAsync(string id) =>
            await httpClient.GetAsync<UserViewModel>($"{id}");

        public async Task<IEnumerable<UserViewModel>> GetFriendsAsync(string id) =>
            await httpClient.GetAsync<List<UserViewModel>>($"friends/{id}");

        public async Task UpdateAsync(UserViewModel viewModel) =>
            await httpClient.PutAsync(string.Empty, viewModel);

        public async Task DeleteAsync(string userId) =>
            await httpClient.DeleteAsync($"{userId}");

        public async Task AddFriendsAsync(FriendsViewModel viewModel) =>
            await httpClient.PostAsync($"friends", viewModel);

        public async Task DeleteFriendsAsync(FriendsViewModel viewModel) =>
            await httpClient.DeleteAsync($"friends/{viewModel.FirstId}/{viewModel.SecondId}");

        public UsersService(HttpClient httpClient) =>
            this.httpClient = new(httpClient);
    }
}
