using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TeamworkSystem.Social.DataAccess.Extensions.Dependencies;

public static class DatabaseExtensions
{
    public static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddTransient<IDbConnection>(_ => new SqlConnection(connectionString));
        services.AddDbContext<SocialDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        return services;
    }
}
