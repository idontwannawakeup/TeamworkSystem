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
        private readonly ApiHttpClient httpClient;

        public async Task<IEnumerable<TicketViewModel>> GetTicketsForUserAsync(string userId) =>
            await httpClient.GetAsync<List<TicketViewModel>>($"?ExecutorId={userId}");

        public async Task<TicketViewModel> GetByIdAsync(int id) =>
            await httpClient.GetAsync<TicketViewModel>($"{id}");

        public async Task<IEnumerable<TicketViewModel>> GetByProjectIdAsync(int projectId) =>
            await httpClient.GetAsync<List<TicketViewModel>>($"?ProjectId={projectId}");

        public async Task DeleteAsync(int id) =>
            await httpClient.DeleteAsync($"{id}");

        public TicketsService(HttpClient httpClient) =>
            this.httpClient = new(httpClient);
    }
}
