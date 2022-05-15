using TeamworkSystem.Shared.Interfaces;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.WorkManagement.DataAccess.Entities;
using TeamworkSystem.WorkManagement.DataAccess.Parameters;

namespace TeamworkSystem.WorkManagement.DataAccess.Interfaces.Repositories;

public interface IProjectsRepository : IRepository<Project>
{
    Task<PagedList<Project>> GetAsync(ProjectsParameters parameters);
}
