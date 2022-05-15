using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Forms;
using TeamworkSystem.WebClient.Authentication;
using TeamworkSystem.WebClient.Extensions;
using TeamworkSystem.WebClient.Interfaces;
using TeamworkSystem.WebClient.Parameters;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Services;

public class UsersService : IUsersService
{
    private readonly ApiHttpClient _httpClient;

    public async Task<IEnumerable<UserViewModel>> GetAsync(UsersParameters parameters) =>
        await _httpClient.GetAsync<List<UserViewModel>>(
            ParametersStringFactory.GenerateParametersString(parameters));

    public async Task<(IEnumerable<UserViewModel>, PaginationHeaderViewModel)> GetWithPaginationHeaderAsync(
        UsersParameters parameters)
    {
        return await _httpClient.GetWithPaginationHeaderAsync<List<UserViewModel>>(
            ParametersStringFactory.GenerateParametersString(parameters));
    }

    public async Task<IEnumerable<UserViewModel>> GetAsync() =>
        await _httpClient.GetAsync<List<UserViewModel>>(string.Empty);

    public async Task<IEnumerable<UserViewModel>> GetByTeamIdAsync(Guid teamId) =>
        await _httpClient.GetAsync<List<UserViewModel>>($"?TeamId={teamId}");

    public async Task<UserViewModel> GetByIdAsync(Guid id) =>
        await _httpClient.GetAsync<UserViewModel>($"{id}");

    public async Task UpdateAsync(UserViewModel viewModel) =>
        await _httpClient.PutAsync(string.Empty, viewModel);

    public async Task SetAvatarForUserAsync(Guid id, IBrowserFile file)
    {
        var buffer = new byte[file.Size];
        await file.OpenReadStream().ReadAsync(buffer);
        var imageContent = new ByteArrayContent(buffer);
        imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse(file.ContentType);

        var userIdContent = new StringContent(id.ToString());

        var requestContent = new MultipartFormDataContent
        {
            { userIdContent, "UserId" },
            { imageContent, "Avatar", file.Name }
        };

        await _httpClient.PostFormDataAsync("avatar", requestContent);
    }

    public async Task DeleteAsync(Guid userId) =>
        await _httpClient.DeleteAsync($"{userId}");

    public UsersService(HttpClient httpClient, ApiAuthenticationStateProvider state) =>
        _httpClient = new ApiHttpClientBuilder(httpClient).AddAuthorization(state).Build();
}
