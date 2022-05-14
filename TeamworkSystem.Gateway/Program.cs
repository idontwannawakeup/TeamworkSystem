using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOcelot();
builder.Configuration.AddJsonFile("ocelot.json");

var app = builder.Build();

app.UseRouting();
app.MapControllers();
await app.UseOcelot();

app.Run();
