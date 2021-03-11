using TeamworkSystem.DataAccessLayer.Entities;

namespace TeamworkSystem.DataAccessLayer.Data
{
    public class UsersRepository : GenericRepository<User>
    {
        public UsersRepository(TeamworkSystemContext context)
            : base(context)
        {
        }
    }
}
