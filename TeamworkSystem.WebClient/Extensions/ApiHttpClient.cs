using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Extensions
{
    public class ApiHttpClient
    {
        private static readonly JsonSerializerOptions options = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private readonly HttpClient httpClient;

        public async Task<T> GetAsync<T>(string requestUri)
        {
            var response = await httpClient.GetAsync(requestUri);
            var responseBody = await response.Content.ReadAsStringAsync();
            StatusCodeHandler.TryHandleStatusCode(response.StatusCode, responseBody);
            return responseBody.Deserialize<T>();
        }

        public async Task<(T, PaginationHeaderViewModel)> GetWithPaginationHeaderAsync<T>(
            string requestUri)
        {
            var response = await httpClient.GetAsync(requestUri);
            var responseBody = await response.Content.ReadAsStringAsync();
            var pagination = response.Headers.GetValues("X-Pagination")
                                             .FirstOrDefault()
                                             .Deserialize<PaginationHeaderViewModel>();

            StatusCodeHandler.TryHandleStatusCode(response.StatusCode, responseBody);
            return (responseBody.Deserialize<T>(), pagination);
        }

        public async Task PostAsync<T>(string requestUri, T viewModel)
        {
            var response = await httpClient.PostAsJsonAsync(requestUri, viewModel, options);
            var responseBody = await response.Content.ReadAsStringAsync();
            StatusCodeHandler.TryHandleStatusCode(response.StatusCode, responseBody);
        }

        public async Task<TOut> PostAsync<T, TOut>(string requestUri, T viewModel)
        {
            var response = await httpClient.PostAsJsonAsync(requestUri, viewModel, options);
            var responseBody = await response.Content.ReadAsStringAsync();
            StatusCodeHandler.TryHandleStatusCode(response.StatusCode, responseBody);
            return responseBody.Deserialize<TOut>();
        }

        public async Task PutAsync<T>(string requestUri, T viewModel)
        {
            var response = await httpClient.PutAsJsonAsync(requestUri, viewModel, options);
            var responseBody = await response.Content.ReadAsStringAsync();
            StatusCodeHandler.TryHandleStatusCode(response.StatusCode, responseBody);
        }

        public async Task DeleteAsync(string requestUri)
        {
            var response = await httpClient.DeleteAsync(requestUri);
            var responseBody = await response.Content.ReadAsStringAsync();
            StatusCodeHandler.TryHandleStatusCode(response.StatusCode, responseBody);
        }

        public ApiHttpClient(HttpClient httpClient) =>
            this.httpClient = httpClient;
    }
}
