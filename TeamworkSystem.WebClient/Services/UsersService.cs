using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Forms;
using TeamworkSystem.WebClient.Authentication;
using TeamworkSystem.WebClient.Extensions;
using TeamworkSystem.WebClient.Interfaces;
using TeamworkSystem.WebClient.Parameters;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApiHttpClient _httpClient;

        public async Task<IEnumerable<UserViewModel>> GetAsync(UsersParameters parameters) =>
            await _httpClient.GetAsync<List<UserViewModel>>(
                ParametersStringFactory.GenerateParametersString(parameters));

        public async Task<(IEnumerable<UserViewModel>, PaginationHeaderViewModel)> GetWithPaginationHeaderAsync(
            UsersParameters parameters)
        {
            return await _httpClient.GetWithPaginationHeaderAsync<List<UserViewModel>>(
                ParametersStringFactory.GenerateParametersString(parameters));
        }

        public async Task<IEnumerable<UserViewModel>> GetAsync() =>
            await _httpClient.GetAsync<List<UserViewModel>>(string.Empty);

        public async Task<IEnumerable<UserViewModel>> GetByTeamIdAsync(int teamId) =>
            await _httpClient.GetAsync<List<UserViewModel>>($"?TeamId={teamId}");

        public async Task<UserViewModel> GetByIdAsync(string id) =>
            await _httpClient.GetAsync<UserViewModel>($"{id}");

        public async Task<IEnumerable<UserViewModel>> GetFriendsAsync(string id) =>
            await _httpClient.GetAsync<List<UserViewModel>>($"friends/{id}");

        public async Task<(IEnumerable<UserViewModel>, PaginationHeaderViewModel)> GetFriendsWithPaginationHeaderAsync(
            string id,
            UsersParameters parameters)
        {
            return await _httpClient.GetWithPaginationHeaderAsync<List<UserViewModel>>(
                $"friends/{id}"
                + $"?{nameof(parameters.PageNumber)}={parameters.PageNumber}"
                + $"&{nameof(parameters.PageSize)}={parameters.PageSize}"
                + $"&{nameof(parameters.LastName)}={parameters.LastName}");
        }

        public async Task UpdateAsync(UserViewModel viewModel) =>
            await _httpClient.PutAsync(string.Empty, viewModel);

        public async Task SetAvatarForUserAsync(string id, IBrowserFile file)
        {
            var buffer = new byte[file.Size];
            await file.OpenReadStream().ReadAsync(buffer);
            var imageContent = new ByteArrayContent(buffer);
            imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse(file.ContentType);

            var userIdContent = new StringContent(id);

            var requestContent = new MultipartFormDataContent
            {
                { userIdContent, "UserId" },
                { imageContent, "Avatar", file.Name }
            };

            await _httpClient.PostFormDataAsync("avatar", requestContent);
        }

        public async Task DeleteAsync(string userId) =>
            await _httpClient.DeleteAsync($"{userId}");

        public async Task AddFriendsAsync(FriendsViewModel viewModel) =>
            await _httpClient.PostAsync("friends", viewModel);

        public async Task DeleteFriendsAsync(FriendsViewModel viewModel) =>
            await _httpClient.DeleteAsync($"friends/{viewModel.FirstId}/{viewModel.SecondId}");

        public UsersService(HttpClient httpClient, ApiAuthenticationStateProvider state) =>
            _httpClient = new ApiHttpClientBuilder(httpClient).AddAuthorization(state).Build();
    }
}
