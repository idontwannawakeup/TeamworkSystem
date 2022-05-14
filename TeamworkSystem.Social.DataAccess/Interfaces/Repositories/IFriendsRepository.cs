using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.Social.DataAccess.Entities;
using TeamworkSystem.Social.DataAccess.Parameters;

namespace TeamworkSystem.Social.DataAccess.Interfaces.Repositories;

public interface IFriendsRepository
{
    Task<IEnumerable<UserProfile>> GetAsync(Guid userId);
    Task<PagedList<UserProfile>> GetAsync(Guid userId, FriendsParameters parameters);
    Task AddToFriendsAsync(Guid firstId, Guid secondId);
    Task DeleteFromFriendsAsync(Guid firstId, Guid secondId);
}
