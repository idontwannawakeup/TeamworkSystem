using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TeamworkSystem.WebClient.Extensions;
using TeamworkSystem.WebClient.Interfaces;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Services
{
    public class TicketsService : ITicketsService
    {
        private readonly HttpClient httpClient;

        public async Task<IEnumerable<TicketViewModel>> GetTicketsForUserAsync(string userId)
        {
            var response = await httpClient.GetAsync($"?ExecutorId={userId}");
            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody.Deserialize<List<TicketViewModel>>();
        }

        public async Task<TicketViewModel> GetByIdAsync(int id)
        {
            var response = await httpClient.GetAsync($"{id}");
            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody.Deserialize<TicketViewModel>();
        }

        public async Task<IEnumerable<TicketViewModel>> GetByProjectIdAsync(int projectId)
        {
            var response = await httpClient.GetAsync($"?ProjectId={projectId}");
            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody.Deserialize<List<TicketViewModel>>();
        }

        public TicketsService(HttpClient httpClient) =>
            this.httpClient = httpClient;
    }
}
