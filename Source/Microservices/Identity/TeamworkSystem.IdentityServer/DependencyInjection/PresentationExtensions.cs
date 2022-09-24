using System.Reflection;
using MassTransit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.Identity.Persistence.Configuration;
using TeamworkSystem.Identity.Persistence.Operational;
using TeamworkSystem.Identity.Persistence.People;
using TeamworkSystem.Identity.Persistence.People.Entities;
using TeamworkSystem.IdentityServer.Settings;

namespace TeamworkSystem.IdentityServer.DependencyInjection;

public static class PresentationExtensions
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton(configuration
                              .GetSection(nameof(DevClientSettings))
                              .Get<DevClientSettings>());

        services.AddMassTransit(massTransitConfiguration =>
        {
            massTransitConfiguration.UsingRabbitMq((_, configurator) =>
            {
                configurator.Host(configuration["EventBusSettings:HostAddress"]);
            });
        });

        services.AddDbContext<PeopleDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("PeopleConnection");
            options.UseSqlServer(connectionString);
        });

        services.AddIdentity<User, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<PeopleDbContext>();

        services.AddIdentityServer()
                .AddAspNetIdentity<User>()
                .AddConfigurationStore(options =>
                {
                    var configurationConnectionString = configuration.GetConnectionString(
                        "IdentityServerConfigurationConnection");

                    var migrationAssembly = typeof(ConfigurationAssembly)
                                            .GetTypeInfo()
                                            .Assembly
                                            .GetName()
                                            .Name;

                    options.ConfigureDbContext = dbBuilder => dbBuilder.UseSqlServer(
                        configurationConnectionString,
                        sqlServerOptions => sqlServerOptions.MigrationsAssembly(migrationAssembly));
                })
                .AddOperationalStore(options =>
                {
                    var operationalConnectionString = configuration.GetConnectionString(
                        "IdentityServerOperationalConnection");

                    var migrationAssembly = typeof(OperationalAssembly)
                                            .GetTypeInfo()
                                            .Assembly
                                            .GetName()
                                            .Name;

                    options.ConfigureDbContext = dbBuilder => dbBuilder.UseSqlServer(
                        operationalConnectionString,
                        sqlServerOptions => sqlServerOptions.MigrationsAssembly(migrationAssembly));
                })
                .AddDeveloperSigningCredential();

        return services;
    }
}
