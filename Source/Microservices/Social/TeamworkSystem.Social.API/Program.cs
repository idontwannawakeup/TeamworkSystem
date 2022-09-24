using TeamworkSystem.Shared.Extensions;
using TeamworkSystem.Social.API.Extensions.Dependencies;
using TeamworkSystem.Social.API.Middlewares;
using TeamworkSystem.Social.BusinessLogic.Extensions.Dependencies;
using TeamworkSystem.Social.DataAccess;
using TeamworkSystem.Social.DataAccess.Extensions.Dependencies;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddCustomLogging(
    builder.Configuration,
    builder.Environment,
    "teamwork-system-social");

builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddBusinessLogic();
builder.Services.AddPresentation(builder.Configuration);

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
    var context = scope.ServiceProvider.GetRequiredService<SocialDbContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    var migrationSucceeded =  await context.Database.TryMigrateAsync();
    if (!migrationSucceeded)
    {
        logger.LogError("Migration failed. Check connection to the server.");
    }
}

await app.RunAsync();
