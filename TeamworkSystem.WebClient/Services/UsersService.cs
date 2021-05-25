using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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

        public async Task<(IEnumerable<UserViewModel>, PaginationHeaderViewModel)> GetFriendsWithPaginationHeaderAsync(
            string id,
            UsersParameters parameters)
        {
            return await httpClient.GetWithPaginationHeaderAsync<List<UserViewModel>>(
                $"friends/{id}"
                + $"?{nameof(parameters.PageNumber)}={parameters.PageNumber}"
                + $"&{nameof(parameters.PageSize)}={parameters.PageSize}"
                + $"&{nameof(parameters.LastName)}={parameters.LastName}");
        }

        public async Task UpdateAsync(UserViewModel viewModel) =>
            await httpClient.PutAsync(string.Empty, viewModel);

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

            await httpClient.PostFormDataAsync("avatar", requestContent);
        }

        public async Task DeleteAsync(string userId) =>
            await httpClient.DeleteAsync($"{userId}");

        public async Task AddFriendsAsync(FriendsViewModel viewModel) =>
            await httpClient.PostAsync($"friends", viewModel);

        public async Task DeleteFriendsAsync(FriendsViewModel viewModel) =>
            await httpClient.DeleteAsync($"friends/{viewModel.FirstId}/{viewModel.SecondId}");

        public UsersService(HttpClient httpClient, ApiAuthenticationStateProvider state) =>
            this.httpClient = new ApiHttpClientBuilder(httpClient).AddAuthorization(state)
                                                                  .Build();
    }
}
