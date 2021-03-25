using System.Threading.Tasks;
using TeamworkSystem.DataAccessLayer.Entities;

namespace TeamworkSystem.DataAccessLayer.Interfaces.Repositories
{
    public interface IProjectsRepository : IRepository<Project>
    {
        Task<Project> GetCompleteProjectAsync(int id);
    }
}
