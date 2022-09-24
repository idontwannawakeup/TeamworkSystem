using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using TeamworkSystem.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddCustomLogging(
    builder.Configuration,
    builder.Environment,
    "teamwork-system-gateway");

builder.Services.AddOcelot().AddCacheManager(x =>
{
    x.WithDictionaryHandle();
});

var ocelotConfigurationFile = builder.Configuration.GetValue<bool>("DOTNET_RUNNING_IN_CONTAINER")
    ? $"ocelot.Docker.{builder.Environment.EnvironmentName}.json"
    : $"ocelot.{builder.Environment.EnvironmentName}.json";

builder.Configuration.AddJsonFile(ocelotConfigurationFile, true, true);

var app = builder.Build();

app.UseRouting();
app.MapControllers();
await app.UseOcelot();

{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Environment - {}", app.Environment.EnvironmentName);
}

app.Run();
