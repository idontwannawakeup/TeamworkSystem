using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.DataAccessLayer.Entities;

namespace TeamworkSystem.DataAccessLayer.Interfaces.Repositories
{
    public interface IUsersRepository : IRepository<User>
    {
        Task<IEnumerable<Team>> GetRelatedTeamsAsync(int id);
    }
}
