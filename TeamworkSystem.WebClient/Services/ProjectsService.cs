using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TeamworkSystem.WebClient.Extensions;
using TeamworkSystem.WebClient.Interfaces;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly HttpClient httpClient;

        public async Task<IEnumerable<ProjectViewModel>> GetByTeamIdAsync(int teamId)
        {
            var response = await httpClient.GetAsync($"?TeamId={teamId}");
            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody.Deserialize<List<ProjectViewModel>>();
        }

        public async Task<IEnumerable<ProjectViewModel>> GetProjectsForTeamMemberAsync(
            string teamMemberId)
        {
            var response = await httpClient.GetAsync($"?TeamMemberId={teamMemberId}");
            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody.Deserialize<List<ProjectViewModel>>();
        }

        public ProjectsService(HttpClient httpClient) =>
            this.httpClient = httpClient;
    }
}
