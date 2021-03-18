using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.DataAccessLayer.Entities;

namespace TeamworkSystem.DataAccessLayer.Interfaces.Repositories
{
    public interface IUsersRepository : IRepository<User>
    {
        Task<IEnumerable<Team>> GetRelatedTeamsAsync(int id);

        Task<IEnumerable<Rating>> GetRatingsForUserAsync(int id);

        Task<IEnumerable<User>> GetFriendsAsync(int id);

        Task AddFriendAsync(int id, int friendId);

        Task DeleteFriendAsync(int id, int friendId);
    }
}
