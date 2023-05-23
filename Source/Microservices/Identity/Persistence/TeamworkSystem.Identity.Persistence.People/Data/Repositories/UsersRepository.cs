using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.Identity.Persistence.People.Common.Filters.Users;
using TeamworkSystem.Identity.Persistence.People.Common.Parameters;
using TeamworkSystem.Identity.Persistence.People.Data.Entities;
using TeamworkSystem.Identity.Persistence.People.Interfaces.Data.Repositories;
using TeamworkSystem.Shared.Exceptions;
using TeamworkSystem.Shared.Extensions;
using TeamworkSystem.Shared.Pagination;

namespace TeamworkSystem.Identity.Persistence.People.Data.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly UserManager<User> _userManager;

    public UsersRepository(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IEnumerable<User>> GetAsync()
    {
        return await _userManager.Users.ToListAsync();
    }

    public async Task<PagedList<User>> GetAsync(UsersParameters parameters)
    {
        var source = _userManager.Users.FilterBy(new LastNameCriterion(parameters));
        return await PagedList<User>.ToPagedListAsync(
            source,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        return user ?? throw new EntityNotFoundException(GetUserNotFoundErrorMessage(id));
    }

    public async Task<User> FindByNameOrThrowAsync(string name)
    {
        var user = await _userManager.FindByNameAsync(name);
        return user ?? throw new EntityNotFoundException(
            $"{nameof(User)} with user name {name} not found.");
    }

    public async Task<User> GetCompleteEntityAsync(Guid id)
    {
        var user = await _userManager.Users.SingleOrDefaultAsync(user => user.Id == id);
        return user ?? throw new EntityNotFoundException(GetUserNotFoundErrorMessage(id));
    }

    public async Task UpdateAsync(User user)
    {
        await _userManager.UpdateAsync(user);
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await GetByIdAsync(id);
        await _userManager.DeleteAsync(user);
    }

    private static string GetUserNotFoundErrorMessage(Guid id) =>
        $"{nameof(User)} with id {id} not found.";
}
