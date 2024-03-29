using TeamworkSystem.Content.API.DependencyInjection;
using TeamworkSystem.Content.API.Middlewares;
using TeamworkSystem.Content.Application.DependencyInjection;
using TeamworkSystem.Content.Persistence;
using TeamworkSystem.Content.Persistence.DependencyInjection;
using TeamworkSystem.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddCustomLogging(
    builder.Configuration,
    builder.Environment,
    "teamwork-system-content");

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddPresentation(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTwsSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

if (app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await using (var scope = app.Services.CreateAsyncScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ContentDbContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    var migrationSucceeded = await context.Database.TryMigrateAsync();
    if (!migrationSucceeded)
    {
        logger.LogError("Migration failed. Check connection to the server.");
    }
}

await app.RunAsync();
