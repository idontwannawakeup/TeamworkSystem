using MassTransit;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.Identity.Persistence.People;
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

services.AddDbContext<PeopleDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("PeopleConnection");
    options.UseSqlServer(connectionString);
});

services.AddIdentityServer()
        .AddConfigurationStore(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("IdentityServerConfigurationConnection");
            options.ConfigureDbContext = dbBuilder => dbBuilder.UseSqlServer(connectionString);
        })
        .AddOperationalStore(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("IdentityServerOperationalConnection");
            options.ConfigureDbContext = dbBuilder => dbBuilder.UseSqlServer(connectionString);
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
