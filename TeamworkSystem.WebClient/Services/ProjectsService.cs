using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TeamworkSystem.WebClient.Extensions;
using TeamworkSystem.WebClient.Interfaces;
using TeamworkSystem.WebClient.Parameters;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly ApiHttpClient httpClient;

        public async Task<IEnumerable<ProjectViewModel>> GetAsync(ProjectsParameters parameters) =>
            await httpClient.GetAsync<List<ProjectViewModel>>(
                ParametersStringFactory.GenerateParametersString(parameters));

        public async Task<(IEnumerable<ProjectViewModel>, PaginationHeaderViewModel)> GetWithPaginationHeaderAsync(
            ProjectsParameters parameters)
        {
            return await httpClient.GetWithPaginationHeaderAsync<List<ProjectViewModel>>(
                ParametersStringFactory.GenerateParametersString(parameters));
        }

        public async Task<IEnumerable<ProjectViewModel>> GetByTeamIdAsync(int teamId) =>
            await httpClient.GetAsync<List<ProjectViewModel>>($"?TeamId={teamId}");

        public async Task<IEnumerable<ProjectViewModel>> GetProjectsForTeamMemberAsync(string teamMemberId) =>
            await httpClient.GetAsync<List<ProjectViewModel>>($"?TeamMemberId={teamMemberId}");

        public async Task<ProjectViewModel> GetByIdAsync(int id) =>
            await httpClient.GetAsync<ProjectViewModel>($"{id}");

        public async Task CreateAsync(ProjectViewModel viewModel) =>
            await httpClient.PostAsync(string.Empty, viewModel);

        public async Task UpdateAsync(ProjectViewModel viewModel) =>
            await httpClient.PutAsync(string.Empty, viewModel);

        public async Task DeleteAsync(int id) =>
            await httpClient.DeleteAsync($"{id}");

        public ProjectsService(HttpClient httpClient) =>
            this.httpClient = new(httpClient);
    }
}
