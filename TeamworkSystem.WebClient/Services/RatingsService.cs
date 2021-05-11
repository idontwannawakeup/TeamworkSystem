using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TeamworkSystem.WebClient.Extensions;
using TeamworkSystem.WebClient.Interfaces;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Services
{
    public class RatingsService : IRatingsService
    {
        private readonly HttpClient httpClient;

        public async Task<IEnumerable<RatingViewModel>> GetByRatedUserId(string userId)
        {
            var response = await httpClient.GetAsync($"?RatedUserId={userId}");
            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody.Deserialize<List<RatingViewModel>>();
        }

        public RatingsService(HttpClient httpClient) =>
            this.httpClient = httpClient;
    }
}
