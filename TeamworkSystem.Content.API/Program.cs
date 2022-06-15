using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TeamworkSystem.Content.API.Consumers;
using TeamworkSystem.Content.API.DependencyInjection;
using TeamworkSystem.Content.API.Middlewares;
using TeamworkSystem.Content.Application.DependencyInjection;
using TeamworkSystem.Content.Application.Common.Settings;
using TeamworkSystem.Content.Persistence;
using TeamworkSystem.Content.Persistence.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddSingleton(_ => new ServicesSettings
{
    WorkManagementUrl = builder.Configuration["ServicesSettings:WorkManagementUrl"]
});

services.AddPersistence(builder.Configuration);
services.AddApplication();
services.AddValidation();
services.AddAuthenticationWithJwtBearer(builder.Configuration);
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.AddRedis(builder.Configuration);

services.AddMassTransit(configuration =>
{
    configuration.AddConsumer<ProjectAddedToRecentEventConsumer>();
    configuration.AddConsumer<TeamAddedToRecentEventConsumer>();
    configuration.AddConsumer<TicketAddedToRecentEventConsumer>();

    configuration.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host(builder.Configuration["EventBusSettings:HostAddress"]);
        configurator.ReceiveEndpoint(
            "content-recent-project",
            endpointConfigurator =>
            {
                endpointConfigurator.ConfigureConsumer<ProjectAddedToRecentEventConsumer>(context);
            });

        configurator.ReceiveEndpoint(
            "content-recent-team",
            endpointConfigurator =>
            {
                endpointConfigurator.ConfigureConsumer<TeamAddedToRecentEventConsumer>(context);
            });

        configurator.ReceiveEndpoint(
            "content-recent-ticket",
            endpointConfigurator =>
            {
                endpointConfigurator.ConfigureConsumer<TicketAddedToRecentEventConsumer>(context);
            });
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "TeamworkSystem.Content.API",
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await using (var scope = app.Services.CreateAsyncScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ContentDbContext>();
    await context.Database.MigrateAsync();
}

app.Run();
