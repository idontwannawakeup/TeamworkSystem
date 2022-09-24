using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.Identity.Persistence.People.Entities;

namespace TeamworkSystem.Identity.Persistence.People.Extensions.Dependencies;

public static class DatabaseDependenciesExtensions
{
    public static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<PeopleDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        });

        services.AddIdentityCore<User>()
                .AddRoles<IdentityRole<Guid>>()
                .AddSignInManager<SignInManager<User>>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<PeopleDbContext>();

        return services;
    }
}
