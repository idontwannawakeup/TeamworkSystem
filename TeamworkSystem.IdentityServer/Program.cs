using MassTransit;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.Identity.DataAccess;
using TeamworkSystem.IdentityServer;
using TeamworkSystem.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddCustomLogging(
    builder.Configuration,
    builder.Environment,
    "teamwork-system-identity-server");

var services = builder.Services;
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

services.AddMassTransit(configuration =>
{
    configuration.UsingRabbitMq((_, configurator) =>
    {
        configurator.Host(builder.Configuration["EventBusSettings:HostAddress"]);
    });
});

services.AddDbContext<IdentityExtDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

services.AddIdentityServer()
        .AddInMemoryClients(IdentityServerConfiguration.Clients)
        .AddInMemoryIdentityResources(IdentityServerConfiguration.IdentityResources)
        .AddInMemoryApiResources(IdentityServerConfiguration.ApiResources)
        .AddInMemoryApiScopes(IdentityServerConfiguration.ApiScopes)
        .AddDeveloperSigningCredential();

services.AddControllersWithViews();
services.AddEndpointsApiExplorer();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseIdentityServer();

app.MapDefaultControllerRoute();

app.Run();
