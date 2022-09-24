using TeamworkSystem.Identity.API.Extensions.Dependencies;
using TeamworkSystem.Identity.API.Middlewares;
using TeamworkSystem.Identity.BusinessLogic.DependencyInjection;
using TeamworkSystem.Identity.Persistence.People.DependencyInjection;
using TeamworkSystem.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddCustomLogging(
    builder.Configuration,
    builder.Environment,
    "teamwork-system-identity");

var services = builder.Services;
services.AddDatabase(builder.Configuration);
services.AddData();
services.AddFilterFactories();
services.AddServices();
services.AddValidation();

services.AddPresentation(builder.Configuration);
services.AddEndpointsApiExplorer();

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
