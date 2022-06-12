using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOcelot().AddCacheManager(x =>
{
    x.WithDictionaryHandle();
});

builder.Configuration.AddJsonFile("ocelot.json", false, reloadOnChange: true);

var app = builder.Build();

app.UseRouting();
app.MapControllers();
await app.UseOcelot();

app.Run();
