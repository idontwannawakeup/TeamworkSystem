using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.BusinessLogicLayer.Interfaces.Services
{
    public interface IProjectsService
    {
        Task<IEnumerable<ProjectResponse>> GetAsync();

        Task<PagedList<ProjectResponse>> GetAsync(ProjectsParameters parameters);

        Task<IEnumerable<ProjectResponse>> GetTeamProjectsAsync(int teamId);

        Task<ProjectResponse> GetByIdAsync(int id);

        Task InsertAsync(ProjectRequest request);

        Task UpdateAsync(ProjectRequest request);

        Task DeleteAsync(int id);
    }
}
