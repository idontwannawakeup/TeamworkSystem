using MassTransit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.Identity.DataAccess;
using TeamworkSystem.Identity.DataAccess.Entities;
using TeamworkSystem.IdentityServer;

var builder = WebApplication.CreateBuilder(args);
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

services.AddIdentity<User, IdentityRole<Guid>>()
        .AddEntityFrameworkStores<IdentityExtDbContext>()
        .AddDefaultTokenProviders();

services.AddIdentityServer()
        .AddAspNetIdentity<User>()
        .AddInMemoryApiResources(IdentityServerConfiguration.ApiResources)
        .AddInMemoryIdentityResources(IdentityServerConfiguration.IdentityResources)
        .AddInMemoryApiScopes(IdentityServerConfiguration.ApiScopes)
        .AddInMemoryClients(IdentityServerConfiguration.Clients)
        .AddDeveloperSigningCredential();

services.ConfigureApplicationCookie(config =>
{
    config.Cookie.Name = "TeamworkSystem.Identity.Cookie";
    config.LoginPath = "/Identity/Login";
    config.LogoutPath = "/Identity/Logout";
});

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
