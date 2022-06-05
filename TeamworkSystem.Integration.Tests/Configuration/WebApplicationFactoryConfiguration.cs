using System.Linq;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TeamworkSystem.DataAccessLayer;

namespace TeamworkSystem.Integration.Tests.Configuration;

public class WebApplicationFactoryConfiguration
{
    public static WebApplicationFactory<Program> GetConfiguredApplication()
    {
        return new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                var context = services.Single(d =>
                    d.ServiceType == typeof(DbContextOptions<TeamworkSystemContext>));

                services.Remove(context);
                services.AddDbContext<TeamworkSystemContext>(options =>
                {
                    options.UseInMemoryDatabase("TeamworkSystemInMemoryDb");
                });
            });
        });
    }
}
