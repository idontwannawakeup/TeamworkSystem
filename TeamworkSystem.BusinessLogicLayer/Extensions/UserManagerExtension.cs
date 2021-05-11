using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Exceptions;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.BusinessLogicLayer.Extensions
{
    public static class UserManagerExtension
    {
        public static async Task<PagedList<User>> GetAsync(
            this UserManager<User> userManager,
            UsersParameters parameters)
        {
            var source = userManager.Users;
            SearchByTeamId(ref source, parameters.TeamId);
            return await PagedList<User>.ToPagedListAsync(
                source,
                parameters.PageNumber,
                parameters.PageSize);
        }

        public static async Task<PagedList<User>> GetFriendsAsync(
            this UserManager<User> userManager,
            string id,
            UsersParameters parameters)
        {
            var user = await userManager.GetByIdAsync(id);
            var source = userManager.Users.Where(
                secondUser => secondUser.Friends.Contains(user));

            return await PagedList<User>.ToPagedListAsync(
                source,
                parameters.PageNumber,
                parameters.PageSize);
        }

        public static async Task<User> GetByIdAsync(
            this UserManager<User> userManager,
            string id)
        {
            var user = await userManager.FindByIdAsync(id)
                ?? throw new EntityNotFoundException(
                    GetUserNotFoundErrorMessage(id));

            return user;
        }

        public static async Task<User> GetCompleteEntityAsync(
            this UserManager<User> userManager,
            string id)
        {
            var user = await userManager.Users
                .Include(user => user.Teams)
                .Include(user => user.Tickets)
                .Include(user => user.MyRatings)
                .Include(user => user.RatingsFromMe)
                .Include(user => user.Friends)
                .Include(user => user.FriendForUsers)
                .SingleOrDefaultAsync(user => user.Id == id)
                    ?? throw new EntityNotFoundException(
                        GetUserNotFoundErrorMessage(id));

            return user;
        }

        private static void SearchByTeamId(
            ref IQueryable<User> source,
            int? teamId)
        {
            if (teamId is null || teamId == 0)
            {
                return;
            }

            source = source.Where(user => user.Teams.Any(team => team.Id == teamId));
        }

        private static string GetUserNotFoundErrorMessage(string id) =>
            $"{nameof(User)} with id {id} not found.";
    }
}
