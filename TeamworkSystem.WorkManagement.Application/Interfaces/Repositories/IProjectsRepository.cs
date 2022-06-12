using TeamworkSystem.Shared.Interfaces;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.WorkManagement.Domain.Entities;
using TeamworkSystem.WorkManagement.Domain.Parameters;

namespace TeamworkSystem.WorkManagement.Application.Interfaces.Repositories;

public interface IProjectsRepository : IRepository<Project>
{
    Task<PagedList<Project>> GetAsync(ProjectsParameters parameters);
}
