using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TeamworkSystem.WebClient.Extensions;
using TeamworkSystem.WebClient.Interfaces;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Services
{
    public class TeamsService : ITeamsService
    {
        private readonly ApiHttpClient httpClient;

        public async Task<IEnumerable<TeamViewModel>> GetTeamsForUserAsync(string userId) =>
            await httpClient.GetAsync<List<TeamViewModel>>($"?UserId={userId}");

        public async Task<TeamViewModel> GetByIdAsync(int id) =>
            await httpClient.GetAsync<TeamViewModel>($"{id}");

        public async Task CreateAsync(TeamViewModel viewModel) =>
            await httpClient.PostAsync(string.Empty, viewModel);

        public async Task UpdateAsync(TeamViewModel viewModel) =>
            await httpClient.PutAsync(string.Empty, viewModel);

        public async Task DeleteAsync(int id) =>
            await httpClient.DeleteAsync($"{id}");

        public TeamsService(HttpClient httpClient) =>
            this.httpClient = new(httpClient);
    }
}
