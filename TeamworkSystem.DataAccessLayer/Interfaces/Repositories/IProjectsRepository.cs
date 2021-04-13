using System.Threading.Tasks;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Interfaces.Repositories
{
    public interface IProjectsRepository : IRepository<Project>
    {
        Task<PagedList<Project>> GetAsync(ProjectsParameters parameters);
    }
}
