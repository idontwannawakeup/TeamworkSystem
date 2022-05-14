using System.Net.Http.Headers;
using System.Text.Json;
using TeamworkSystem.WebClient.Authentication;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Extensions
{
    public class ApiHttpClient
    {
        private static readonly JsonSerializerOptions Options = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private readonly HttpClient _httpClient;
        private readonly ApiAuthenticationStateProvider _stateProvider;

        public async Task<T> GetAsync<T>(string requestUri)
        {
            _httpClient.DefaultRequestHeaders.Authorization = await GenerateAuthorizationHeaderAsync();
            var response = await _httpClient.GetAsync(requestUri);
            var responseBody = await response.Content.ReadAsStringAsync();
            StatusCodeHandler.TryHandleStatusCode(response.StatusCode, responseBody);
            return responseBody.Deserialize<T>();
        }

        public async Task<(T, PaginationHeaderViewModel)> GetWithPaginationHeaderAsync<T>(
            string requestUri)
        {
            _httpClient.DefaultRequestHeaders.Authorization = await GenerateAuthorizationHeaderAsync();
            var response = await _httpClient.GetAsync(requestUri)!;
            var responseBody = await response.Content.ReadAsStringAsync();
            StatusCodeHandler.TryHandleStatusCode(response.StatusCode, responseBody);
            var pagination = response.Headers.GetValues("X-Pagination")
                                             .First()
                                             .Deserialize<PaginationHeaderViewModel>();

            return (responseBody.Deserialize<T>(), pagination);
        }

        public async Task PostAsync<T>(string requestUri, T viewModel)
        {
            _httpClient.DefaultRequestHeaders.Authorization = await GenerateAuthorizationHeaderAsync();
            var response = await _httpClient.PostAsJsonAsync(requestUri, viewModel, Options);
            var responseBody = await response.Content.ReadAsStringAsync();
            StatusCodeHandler.TryHandleStatusCode(response.StatusCode, responseBody);
        }

        public async Task PostFormDataAsync(string requestUri, MultipartFormDataContent content)
        {
            _httpClient.DefaultRequestHeaders.Authorization = await GenerateAuthorizationHeaderAsync();
            var response = await _httpClient.PostAsync(requestUri, content);
            var responseBody = await response.Content.ReadAsStringAsync();
            StatusCodeHandler.TryHandleStatusCode(response.StatusCode, responseBody);
        }

        public async Task<TOut> PostAsync<T, TOut>(string requestUri, T viewModel)
        {
            _httpClient.DefaultRequestHeaders.Authorization = await GenerateAuthorizationHeaderAsync();
            var response = await _httpClient.PostAsJsonAsync(requestUri, viewModel, Options);
            var responseBody = await response.Content.ReadAsStringAsync();
            StatusCodeHandler.TryHandleStatusCode(response.StatusCode, responseBody);
            return responseBody.Deserialize<TOut>();
        }

        public async Task<TOut> PostWithoutAuthorizationAsync<T, TOut>(string requestUri, T viewModel)
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
            var response = await _httpClient.PostAsJsonAsync(requestUri, viewModel, Options);
            var responseBody = await response.Content.ReadAsStringAsync();
            StatusCodeHandler.TryHandleStatusCode(response.StatusCode, responseBody);
            return responseBody.Deserialize<TOut>();
        }

        public async Task PutAsync<T>(string requestUri, T viewModel)
        {
            _httpClient.DefaultRequestHeaders.Authorization = await GenerateAuthorizationHeaderAsync();
            var response = await _httpClient.PutAsJsonAsync(requestUri, viewModel, Options);
            var responseBody = await response.Content.ReadAsStringAsync();
            StatusCodeHandler.TryHandleStatusCode(response.StatusCode, responseBody);
        }

        public async Task DeleteAsync(string requestUri)
        {
            var response = await _httpClient.DeleteAsync(requestUri);
            var responseBody = await response.Content.ReadAsStringAsync();
            StatusCodeHandler.TryHandleStatusCode(response.StatusCode, responseBody);
        }

        private async Task<AuthenticationHeaderValue> GenerateAuthorizationHeaderAsync() =>
            new("bearer", await _stateProvider.GetJwtTokenAsync());

        public ApiHttpClient(HttpClient httpClient, ApiAuthenticationStateProvider stateProvider)
        {
            _httpClient = httpClient;
            _stateProvider = stateProvider;
        }
    }
}
