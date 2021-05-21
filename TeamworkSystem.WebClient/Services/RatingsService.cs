﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TeamworkSystem.WebClient.Extensions;
using TeamworkSystem.WebClient.Interfaces;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Services
{
    public class RatingsService : IRatingsService
    {
        private readonly ApiHttpClient httpClient;

        public async Task<IEnumerable<RatingViewModel>> GetByRatedUserId(string userId) =>
            await httpClient.GetAsync<List<RatingViewModel>>($"?RatedUserId={userId}");

        public async Task CreateAsync(RatingViewModel viewModel) =>
            await httpClient.PostAsync(string.Empty, viewModel);

        public async Task UpdateAsync(RatingViewModel viewModel) =>
            await httpClient.PutAsync(string.Empty, viewModel);

        public async Task DeleteAsync(int id) =>
            await httpClient.DeleteAsync($"{id}");

        public RatingsService(HttpClient httpClient) =>
            this.httpClient = new(httpClient);
    }
}
