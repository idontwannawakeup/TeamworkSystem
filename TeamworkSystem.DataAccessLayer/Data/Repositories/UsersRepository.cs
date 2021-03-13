using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;

namespace TeamworkSystem.DataAccessLayer.Data.Repositories
{
    public class UsersRepository
        : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(TeamworkSystemContext context)
            : base(context)
        {
        }
    }
}
