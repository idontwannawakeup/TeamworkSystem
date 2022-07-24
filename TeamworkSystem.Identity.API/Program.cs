using MassTransit;
using Microsoft.OpenApi.Models;
using TeamworkSystem.Identity.API.Middlewares;
using TeamworkSystem.Identity.BusinessLogic.DependencyInjection;
using TeamworkSystem.Identity.DataAccess;
using TeamworkSystem.Identity.DataAccess.DependencyInjection;
using TeamworkSystem.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddDatabase(builder.Configuration);
services.AddData();
services.AddFilterFactories();
services.AddServices();
services.AddSeeding();
services.AddValidation();
services.AddAuthenticationWithJwtBearer(builder.Configuration);

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

services.AddMassTransit(configuration =>
{
    configuration.UsingRabbitMq((_, configurator) =>
    {
        configurator.Host(builder.Configuration["EventBusSettings:HostAddress"]);
    });
});

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "TeamworkSystem.Identity.API",
            Version = "v1"
        });

    c.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            Description = @"JWT Authorization header using the Bearer scheme.
                            Enter 'Bearer' [space] and then your token in the
                            text input below. Example: 'Bearer 12345abcdef'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await using (var scope = app.Services.CreateAsyncScope())
{
    var context = scope.ServiceProvider.GetRequiredService<IdentityExtDbContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    var migrationSucceeded = await context.Database.TryMigrateAsync();
    if (!migrationSucceeded)
    {
        logger.LogError("Migration failed. Check connection to the server.");
    }
}

await app.RunAsync();
