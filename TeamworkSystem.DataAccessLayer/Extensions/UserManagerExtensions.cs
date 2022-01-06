using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Exceptions;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Extensions;

public static class UserManagerExtensions
{
    public static async Task<PagedList<User>> GetAsync(this UserManager<User> userManager,
                                                       UsersParameters parameters)
    {
        var source = userManager.Users;

        SearchByTeamId(ref source, parameters.TeamId);
        SearchByLastName(ref source, parameters.LastName);

        return await PagedList<User>.ToPagedListAsync(
            source,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public static async Task<PagedList<User>> GetFriendsAsync(this UserManager<User> userManager,
                                                              string id,
                                                              UsersParameters parameters)
    {
        var user = await userManager.GetByIdAsync(id);
        var source = userManager.Users.Where(secondUser => secondUser.Friends.Contains(user));

        SearchByLastName(ref source, parameters.LastName);

        return await PagedList<User>.ToPagedListAsync(
            source,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public static async Task<User> GetByIdAsync(this UserManager<User> userManager, string id)
    {
        var user = await userManager.FindByIdAsync(id);
        return user ?? throw new EntityNotFoundException(GetUserNotFoundErrorMessage(id));
    }

    public static async Task<User> GetCompleteEntityAsync(this UserManager<User> userManager,
                                                          string id)
    {
        var user = await userManager.Users.Include(user => user.Teams)
                                    .Include(user => user.Tickets)
                                    .Include(user => user.MyRatings)
                                    .Include(user => user.Friends)
                                    .SingleOrDefaultAsync(user => user.Id == id);

        return user ?? throw new EntityNotFoundException(GetUserNotFoundErrorMessage(id));
    }

    private static void SearchByTeamId(ref IQueryable<User> source, int? teamId)
    {
        if (teamId is null or 0)
        {
            return;
        }

        source = source.Where(user => user.Teams.Any(team => team.Id == teamId));
    }

    private static void SearchByLastName(ref IQueryable<User> source, string? lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
        {
            return;
        }

        source = source.Where(user => user.LastName.Contains(lastName));
    }

    private static string GetUserNotFoundErrorMessage(string id) =>
        $"{nameof(User)} with id {id} not found.";
}
