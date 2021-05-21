using System.Net.Http;

namespace TeamworkSystem.WebClient.Extensions
{
    public class ApiHttpClientBuilder
    {
        private readonly HttpClient httpClient;

        public ApiHttpClientBuilder AddAuthorization(string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new("bearer", token);
            return this;
        }

        public ApiHttpClient Build() => new(httpClient);

        public ApiHttpClientBuilder(HttpClient httpClient) => this.httpClient = httpClient;
    }
}
