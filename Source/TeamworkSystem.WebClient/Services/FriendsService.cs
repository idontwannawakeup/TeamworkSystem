using TeamworkSystem.WebClient.Authentication;
using TeamworkSystem.WebClient.Extensions;
using TeamworkSystem.WebClient.Interfaces;
using TeamworkSystem.WebClient.Parameters;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Services;

public class FriendsService : IFriendsService
{
    private readonly ApiHttpClient _httpClient;

    public async Task<IEnumerable<UserViewModel>> GetFriendsAsync(Guid id) =>
        await _httpClient.GetAsync<List<UserViewModel>>($"friends/{id}");

    public async Task<(IEnumerable<UserViewModel>, PaginationHeaderViewModel)>
        GetFriendsWithPaginationHeaderAsync(Guid id, FriendsParameters parameters)
    {
        return await _httpClient.GetWithPaginationHeaderAsync<List<UserViewModel>>(
            $"{id}"
            + $"?{nameof(parameters.PageNumber)}={parameters.PageNumber}"
            + $"&{nameof(parameters.PageSize)}={parameters.PageSize}"
            + $"&{nameof(parameters.LastName)}={parameters.LastName}");
    }

    public async Task AddFriendsAsync(FriendsViewModel viewModel) =>
        await _httpClient.PostAsync($"{viewModel.FirstId}/{viewModel.SecondId}");

    public async Task DeleteFriendsAsync(FriendsViewModel viewModel) =>
        await _httpClient.DeleteAsync($"{viewModel.FirstId}/{viewModel.SecondId}");

    public FriendsService(HttpClient httpClient, ApiAuthenticationStateProvider state) =>
        _httpClient = new ApiHttpClientBuilder(httpClient).AddAuthorization(state).Build();
}
