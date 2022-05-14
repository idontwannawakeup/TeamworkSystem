using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Forms;
using TeamworkSystem.WebClient.Authentication;
using TeamworkSystem.WebClient.Extensions;
using TeamworkSystem.WebClient.Interfaces;
using TeamworkSystem.WebClient.Parameters;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Services
{
    public class TeamsService : ITeamsService
    {
        private readonly ApiHttpClient _httpClient;

        public async Task<IEnumerable<TeamViewModel>> GetAsync(TeamsParameters parameters) =>
            await _httpClient.GetAsync<List<TeamViewModel>>(
                ParametersStringFactory.GenerateParametersString(parameters));

        public async Task<(IEnumerable<TeamViewModel>, PaginationHeaderViewModel)> GetWithPaginationHeaderAsync(
            TeamsParameters parameters)
        {
            return await _httpClient.GetWithPaginationHeaderAsync<List<TeamViewModel>>(
                ParametersStringFactory.GenerateParametersString(parameters));
        }

        public async Task<IEnumerable<TeamViewModel>> GetTeamsForUserAsync(Guid userId) =>
            await _httpClient.GetAsync<List<TeamViewModel>>($"?UserId={userId}");

        public async Task<TeamViewModel> GetByIdAsync(Guid id) =>
            await _httpClient.GetAsync<TeamViewModel>($"{id}");

        public async Task CreateAsync(TeamViewModel viewModel) =>
            await _httpClient.PostAsync(string.Empty, viewModel);

        public async Task UpdateAsync(TeamViewModel viewModel) =>
            await _httpClient.PutAsync(string.Empty, viewModel);

        public async Task SetAvatarForTeamAsync(Guid id, IBrowserFile file)
        {
            var buffer = new byte[file.Size];
            await file.OpenReadStream().ReadAsync(buffer);
            var imageContent = new ByteArrayContent(buffer);
            imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse(file.ContentType);

            var userIdContent = new StringContent(id.ToString());

            var requestContent = new MultipartFormDataContent
            {
                { userIdContent, "TeamId" },
                { imageContent, "Avatar", file.Name }
            };

            await _httpClient.PostFormDataAsync("avatar", requestContent);
        }

        public async Task DeleteAsync(Guid id) => await _httpClient.DeleteAsync($"{id}");

        public async Task AddMemberAsync(TeamMemberViewModel viewModel) =>
            await _httpClient.PostAsync("members", viewModel);

        public async Task DeleteMemberAsync(TeamMemberViewModel viewModel) =>
            await _httpClient.DeleteAsync($"members/{viewModel.TeamId}/{viewModel.UserId}");

        public TeamsService(HttpClient httpClient, ApiAuthenticationStateProvider state) =>
            _httpClient = new ApiHttpClientBuilder(httpClient).AddAuthorization(state).Build();
    }
}
