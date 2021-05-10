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
        private readonly HttpClient httpClient;

        public async Task<IEnumerable<TeamViewModel>> GetTeamsForUserAsync(string userId)
        {
            var response = await httpClient.GetAsync($"?UserId={userId}");
            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody.Deserialize<List<TeamViewModel>>();
        }

        public async Task<TeamViewModel> GetByIdAsync(int id)
        {
            var response = await httpClient.GetAsync($"{id}");
            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody.Deserialize<TeamViewModel>();
        }

        public TeamsService(HttpClient httpClient) =>
            this.httpClient = httpClient;
    }
}
