using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.Identity.DataAccess.Entities;
using TeamworkSystem.Identity.DataAccess.Filters.Users;
using TeamworkSystem.Identity.DataAccess.Parameters;
using TeamworkSystem.Shared.Exceptions;
using TeamworkSystem.Shared.Extensions;
using TeamworkSystem.Shared.Pagination;

namespace TeamworkSystem.Identity.DataAccess.Extensions;

public static class UserManagerExtensions
{
    public static async Task<PagedList<User>> GetAsync(
        this UserManager<User> userManager,
        UsersParameters parameters)
    {
        var source = userManager.Users.FilterBy(new LastNameCriterion(parameters));
        return await PagedList<User>.ToPagedListAsync(
            source,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public static async Task<User> GetByIdAsync(
        this UserManager<User> userManager,
        Guid id)
    {
        var user = await userManager.FindByIdAsync(id.ToString());
        return user ?? throw new EntityNotFoundException(GetUserNotFoundErrorMessage(id));
    }

    public static async Task<User> FindByNameOrThrowAsync(
        this UserManager<User> userManager,
        string name)
    {
        var user = await userManager.FindByNameAsync(name);
        return user ?? throw new EntityNotFoundException(
            $"{nameof(User)} with user name {name} not found.");
    }

    public static async Task<User> GetCompleteEntityAsync(
        this UserManager<User> userManager,
        Guid id)
    {
        var user = await userManager.Users.SingleOrDefaultAsync(user => user.Id == id);
        return user ?? throw new EntityNotFoundException(GetUserNotFoundErrorMessage(id));
    }

    private static string GetUserNotFoundErrorMessage(Guid id) =>
        $"{nameof(User)} with id {id} not found.";
}
