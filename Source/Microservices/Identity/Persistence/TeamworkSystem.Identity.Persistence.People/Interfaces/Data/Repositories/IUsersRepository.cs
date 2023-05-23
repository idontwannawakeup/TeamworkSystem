using TeamworkSystem.Identity.Persistence.People.Common.Parameters;
using TeamworkSystem.Identity.Persistence.People.Data.Entities;
using TeamworkSystem.Shared.Pagination;

namespace TeamworkSystem.Identity.Persistence.People.Interfaces.Data.Repositories;

public interface IUsersRepository
{
    Task<IEnumerable<User>> GetAsync();
    Task<PagedList<User>> GetAsync(UsersParameters parameters);
    Task<User> GetByIdAsync(Guid id);
    Task<User> FindByNameOrThrowAsync(string name);
    Task<User> GetCompleteEntityAsync(Guid id);
    Task UpdateAsync(User user);
    Task DeleteAsync(Guid id);
}
