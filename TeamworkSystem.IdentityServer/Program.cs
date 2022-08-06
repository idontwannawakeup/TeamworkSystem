using System.Reflection;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.Identity.Persistence.Configuration;
using TeamworkSystem.Identity.Persistence.Operational;
using TeamworkSystem.Identity.Persistence.People;
using TeamworkSystem.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddCustomLogging(
    builder.Configuration,
    builder.Environment,
    "teamwork-system-identity-server");

var services = builder.Services;

services.AddMassTransit(configuration =>
{
    configuration.UsingRabbitMq((_, configurator) =>
    {
        configurator.Host(builder.Configuration["EventBusSettings:HostAddress"]);
    });
});

services.AddDbContext<PeopleDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("PeopleConnection");
    options.UseSqlServer(connectionString);
});

services.AddIdentityServer()
        .AddConfigurationStore(options =>
        {
            var configurationConnectionString = builder.Configuration.GetConnectionString(
                "IdentityServerConfigurationConnection");

            var migrationAssembly = typeof(ConfigurationAssembly).GetTypeInfo().Assembly.GetName().Name;
            options.ConfigureDbContext = dbBuilder => dbBuilder.UseSqlServer(
                configurationConnectionString,
                sqlServerOptions => sqlServerOptions.MigrationsAssembly(migrationAssembly));
        })
        .AddOperationalStore(options =>
        {
            var operationalConnectionString = builder.Configuration.GetConnectionString(
                "IdentityServerOperationalConnection");

            var migrationAssembly = typeof(OperationalAssembly).GetTypeInfo().Assembly.GetName().Name;
            options.ConfigureDbContext = dbBuilder => dbBuilder.UseSqlServer(
                operationalConnectionString,
                sqlServerOptions => sqlServerOptions.MigrationsAssembly(migrationAssembly));
        })
        .AddDeveloperSigningCredential();

services.AddControllersWithViews();
services.AddEndpointsApiExplorer();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();
