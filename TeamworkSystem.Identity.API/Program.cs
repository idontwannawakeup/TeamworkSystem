using TeamworkSystem.Identity.API.Extensions.Dependencies;
using TeamworkSystem.Identity.API.Middlewares;
using TeamworkSystem.Identity.BusinessLogic.Extensions.Dependencies;
using TeamworkSystem.Identity.Persistence.People.Extensions.Dependencies;
using TeamworkSystem.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddCustomLogging(
    builder.Configuration,
    builder.Environment,
    "teamwork-system-identity");

builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddBusinessLogic();
builder.Services.AddPresentation(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();

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

app.UseRouting();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
