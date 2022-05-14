using TeamworkSystem.WebClient.Authentication;
using TeamworkSystem.WebClient.Extensions;
using TeamworkSystem.WebClient.Interfaces;
using TeamworkSystem.WebClient.Parameters;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly ApiHttpClient _httpClient;

        public async Task<IEnumerable<ProjectViewModel>> GetAsync(ProjectsParameters parameters) =>
            await _httpClient.GetAsync<List<ProjectViewModel>>(
                ParametersStringFactory.GenerateParametersString(parameters));

        public async Task<(IEnumerable<ProjectViewModel>, PaginationHeaderViewModel)> GetWithPaginationHeaderAsync(
            ProjectsParameters parameters)
        {
            return await _httpClient.GetWithPaginationHeaderAsync<List<ProjectViewModel>>(
                ParametersStringFactory.GenerateParametersString(parameters));
        }

        public async Task<IEnumerable<ProjectViewModel>> GetByTeamIdAsync(Guid teamId) =>
            await _httpClient.GetAsync<List<ProjectViewModel>>($"?TeamId={teamId}");

        public async Task<IEnumerable<ProjectViewModel>> GetProjectsForTeamMemberAsync(
            Guid teamMemberId) =>
            await _httpClient.GetAsync<List<ProjectViewModel>>($"?TeamMemberId={teamMemberId}");

        public async Task<ProjectViewModel> GetByIdAsync(Guid id) =>
            await _httpClient.GetAsync<ProjectViewModel>($"{id}");

        public async Task CreateAsync(ProjectViewModel viewModel) =>
            await _httpClient.PostAsync(string.Empty, viewModel);

        public async Task UpdateAsync(ProjectViewModel viewModel) =>
            await _httpClient.PutAsync(string.Empty, viewModel);

        public async Task DeleteAsync(Guid id) =>
            await _httpClient.DeleteAsync($"{id}");

        public ProjectsService(HttpClient httpClient, ApiAuthenticationStateProvider state) =>
            _httpClient = new ApiHttpClientBuilder(httpClient).AddAuthorization(state).Build();
    }
}
