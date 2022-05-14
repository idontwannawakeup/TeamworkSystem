using TeamworkSystem.WebClient.Authentication;
using TeamworkSystem.WebClient.Extensions;
using TeamworkSystem.WebClient.Interfaces;
using TeamworkSystem.WebClient.Parameters;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Services
{
    public class RatingsService : IRatingsService
    {
        private readonly ApiHttpClient _httpClient;

        public async Task<IEnumerable<RatingViewModel>> GetAsync(RatingsParameters parameters) =>
            await _httpClient.GetAsync<List<RatingViewModel>>(
                ParametersStringFactory.GenerateParametersString(parameters));

        public async Task<(IEnumerable<RatingViewModel>, PaginationHeaderViewModel)> GetWithPaginationHeaderAsync(
            RatingsParameters parameters)
        {
            return await _httpClient.GetWithPaginationHeaderAsync<List<RatingViewModel>>(
                ParametersStringFactory.GenerateParametersString(parameters));
        }

        public async Task<IEnumerable<RatingViewModel>> GetByRatedUserId(Guid userId) =>
            await _httpClient.GetAsync<List<RatingViewModel>>($"?RatedUserId={userId}");

        public async Task<RatingViewModel> GetByIdAsync(Guid id) =>
            await _httpClient.GetAsync<RatingViewModel>($"{id}");

        public async Task CreateAsync(RatingViewModel viewModel) =>
            await _httpClient.PostAsync(string.Empty, viewModel);

        public async Task UpdateAsync(RatingViewModel viewModel) =>
            await _httpClient.PutAsync(string.Empty, viewModel);

        public async Task DeleteAsync(Guid id) =>
            await _httpClient.DeleteAsync($"{id}");

        public RatingsService(HttpClient httpClient, ApiAuthenticationStateProvider state) =>
            _httpClient = new ApiHttpClientBuilder(httpClient).AddAuthorization(state).Build();
    }
}
