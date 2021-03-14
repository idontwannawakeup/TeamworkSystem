using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;

namespace TeamworkSystem.DataAccessLayer.Data.Repositories
{
    public class UsersRepository
        : GenericRepository<User>, IUsersRepository
    {
        public async Task<IEnumerable<Team>> GetRelatedTeamsAsync(int id)
        {
            User user = await this.table
                .Include(user => user.Teams)
                .FirstOrDefaultAsync(user => user.Id == id);

            return user?.Teams
                ?? throw new Exception($"{typeof(User).Name} not found.");
        }

        public async Task<IEnumerable<Rating>> GetRatingsForUserAsync(int id)
        {
            User user = await this.table
                .Include(user => user.MyRatings)
                .FirstOrDefaultAsync(user => user.Id == id);

            return user?.MyRatings
                ?? throw new Exception($"{typeof(User).Name} not found.");
        }

        public async Task<IEnumerable<User>> GetFriendsAsync(int id)
        {
            User user = await this.table
                .Include(user => user.Friends)
                .FirstOrDefaultAsync(user => user.Id == id);

            return user?.Friends
                ?? throw new Exception($"{typeof(User).Name} not found.");
        }

        public async Task AddFriendAsync(int id, int friendId)
        {
            User user = await this.table
                .Include(user => user.Friends)
                .FirstOrDefaultAsync(user => user.Id == id);

            User friend = await this.table
                .Include(user => user.Friends)
                .FirstOrDefaultAsync(user => user.Id == friendId);

            user?.Friends.Add(friend);
            friend?.Friends.Add(user);
        }

        public async Task DeleteFriendAsync(int id, int friendId)
        {
            User user = await this.table
                .Include(user => user.Friends)
                .FirstOrDefaultAsync(user => user.Id == id);

            User friend = await this.table
                .Include(user => user.Friends)
                .FirstOrDefaultAsync(user => user.Id == friendId);

            user?.Friends.Remove(friend);
            friend?.Friends.Remove(user);
        }

        public UsersRepository(TeamworkSystemContext databaseContext)
            : base(databaseContext)
        {
        }
    }
}
