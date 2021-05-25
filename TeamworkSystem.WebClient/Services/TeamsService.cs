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
    public class TeamsService : ITeamsService
    {
        private readonly ApiHttpClient httpClient;

        public async Task<IEnumerable<TeamViewModel>> GetAsync(TeamsParameters parameters) =>
            await httpClient.GetAsync<List<TeamViewModel>>(
                ParametersStringFactory.GenerateParametersString(parameters));

        public async Task<(IEnumerable<TeamViewModel>, PaginationHeaderViewModel)> GetWithPaginationHeaderAsync(
            TeamsParameters parameters)
        {
            return await httpClient.GetWithPaginationHeaderAsync<List<TeamViewModel>>(
                ParametersStringFactory.GenerateParametersString(parameters));
        }

        public async Task<IEnumerable<TeamViewModel>> GetTeamsForUserAsync(string userId) =>
            await httpClient.GetAsync<List<TeamViewModel>>($"?UserId={userId}");

        public async Task<TeamViewModel> GetByIdAsync(int id) =>
            await httpClient.GetAsync<TeamViewModel>($"{id}");

        public async Task CreateAsync(TeamViewModel viewModel) =>
            await httpClient.PostAsync(string.Empty, viewModel);

        public async Task UpdateAsync(TeamViewModel viewModel) =>
            await httpClient.PutAsync(string.Empty, viewModel);

        public async Task SetAvatarForTeamAsync(int id, IBrowserFile file)
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

            await httpClient.PostFormDataAsync("avatar", requestContent);
        }

        public async Task DeleteAsync(int id) =>
            await httpClient.DeleteAsync($"{id}");

        public async Task AddMemberAsync(TeamMemberViewModel viewModel) =>
            await httpClient.PostAsync($"members", viewModel);

        public async Task DeleteMemberAsync(TeamMemberViewModel viewModel) =>
            await httpClient.DeleteAsync($"members/{viewModel.TeamId}/{viewModel.UserId}");

        public TeamsService(HttpClient httpClient, ApiAuthenticationStateProvider state) =>
            this.httpClient = new ApiHttpClientBuilder(httpClient).AddAuthorization(state)
                                                                  .Build();
    }
}
