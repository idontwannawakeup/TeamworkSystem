using TeamworkSystem.WebClient.Authentication;
using TeamworkSystem.WebClient.Extensions;
using TeamworkSystem.WebClient.Interfaces;
using TeamworkSystem.WebClient.Parameters;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Services
{
    public class TicketsService : ITicketsService
    {
        private readonly ApiHttpClient _httpClient;

        public async Task<IEnumerable<TicketViewModel>> GetAsync(TicketsParameters parameters) =>
            await _httpClient.GetAsync<List<TicketViewModel>>(
                ParametersStringFactory.GenerateParametersString(parameters));

        public async Task<(IEnumerable<TicketViewModel>, PaginationHeaderViewModel)> GetWithPaginationHeaderAsync(
            TicketsParameters parameters)
        {
            return await _httpClient.GetWithPaginationHeaderAsync<List<TicketViewModel>>(
                ParametersStringFactory.GenerateParametersString(parameters));
        }

        public async Task<IEnumerable<TicketViewModel>> GetTicketsForUserAsync(string userId) =>
            await _httpClient.GetAsync<List<TicketViewModel>>($"?ExecutorId={userId}");

        public async Task<TicketViewModel> GetByIdAsync(int id) =>
            await _httpClient.GetAsync<TicketViewModel>($"{id}");

        public async Task<IEnumerable<TicketViewModel>> GetByProjectIdAsync(int projectId) =>
            await _httpClient.GetAsync<List<TicketViewModel>>($"?ProjectId={projectId}");

        public async Task CreateAsync(TicketViewModel viewModel) =>
            await _httpClient.PostAsync(string.Empty, viewModel);

        public async Task UpdateAsync(TicketViewModel viewModel) =>
            await _httpClient.PutAsync(string.Empty, viewModel);

        public async Task DeleteAsync(int id) =>
            await _httpClient.DeleteAsync($"{id}");

        public TicketsService(HttpClient httpClient, ApiAuthenticationStateProvider state) =>
            _httpClient = new ApiHttpClientBuilder(httpClient).AddAuthorization(state).Build();
    }
}
