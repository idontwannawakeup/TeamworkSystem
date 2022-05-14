using TeamworkSystem.Core.DataAccess.Entities;
using TeamworkSystem.Core.DataAccess.Parameters;
using TeamworkSystem.Shared.Interfaces;
using TeamworkSystem.Shared.Pagination;

namespace TeamworkSystem.Core.DataAccess.Interfaces.Repositories;

public interface IProjectsRepository : IRepository<Project>
{
    Task<PagedList<Project>> GetAsync(ProjectsParameters parameters);
}
