using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.DataAccessLayer.Entities;

namespace TeamworkSystem.DataAccessLayer.Interfaces.Repositories
{
    public interface ITeamsRepository : IRepository<Team>
    {
        Task<IEnumerable<User>> GetMembersAsync(int id);
    }
}
