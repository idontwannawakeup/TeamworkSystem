using Microsoft.AspNetCore.Identity;
using TeamworkSystem.Identity.DataAccess.Entities;

namespace TeamworkSystem.Identity.DataAccess.Interfaces;

public interface IUnitOfWork
{
    UserManager<User> UserManager { get; }

    Task SaveChangesAsync();
}
