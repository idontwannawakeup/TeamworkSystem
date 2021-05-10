using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TeamworkSystem.WebClient.Extensions;
using TeamworkSystem.WebClient.Interfaces;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Services
{
    public class UsersService : IUsersService
    {
        private readonly HttpClient httpClient;

        public async Task<IEnumerable<UserViewModel>> GetByTeamIdAsync(int teamId)
        {
            var response = await httpClient.GetAsync($"?TeamId={teamId}");
            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody.Deserialize<List<UserViewModel>>();
        }

        public async Task<UserViewModel> GetByIdAsync(string id)
        {
            var response = await httpClient.GetAsync($"{id}");
            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody.Deserialize<UserViewModel>();
        }

        public UsersService(HttpClient httpClient) =>
            this.httpClient = httpClient;
    }
}
