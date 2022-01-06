using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TeamworkSystem.DataAccessLayer;

public class TeamworkSystemContextFactory : IDesignTimeDbContextFactory<TeamworkSystemContext>
{
    public TeamworkSystemContext CreateDbContext(string[] args)
    {
        IConfiguration config = new ConfigurationBuilder()
                                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),
                                    "../TeamworkSystem.WebAPI"))
                                .AddJsonFile("appsettings.json")
                                .Build();

        var optionsBuilder = new DbContextOptionsBuilder<TeamworkSystemContext>();
        optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        return new TeamworkSystemContext(optionsBuilder.Options);
    }
}
