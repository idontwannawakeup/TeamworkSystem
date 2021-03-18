using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.DataAccessLayer.Entities;

namespace TeamworkSystem.DataAccessLayer.Interfaces.Repositories
{
    public interface ITeamsRepository : IRepository<Team>
    {
        Task<IEnumerable<User>> GetMembersAsync(int id);

        Task AddMemberAsync(int id, User member);

        Task DeleteMemberAsync(int id, User member);
    }
}
