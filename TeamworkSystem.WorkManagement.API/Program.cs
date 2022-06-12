using MassTransit;
using Microsoft.OpenApi.Models;
using TeamworkSystem.WorkManagement.API.Consumers;
using TeamworkSystem.WorkManagement.API.DependencyInjection;
using TeamworkSystem.WorkManagement.API.Middlewares;
using TeamworkSystem.WorkManagement.Application.DependencyInjection;
using TeamworkSystem.WorkManagement.Persistence.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddPersistence(builder.Configuration);
services.AddApplication();
services.AddValidation();
services.AddAuthenticationWithJwtBearer(builder.Configuration);
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

services.AddMassTransit(configuration =>
{
    configuration.AddConsumer<UserCreatedEventConsumer>();
    configuration.AddConsumer<UserAvatarChangedEventConsumer>();

    configuration.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host(builder.Configuration["EventBusSettings:HostAddress"]);
        configurator.ReceiveEndpoint(
            "work-management-user-created",
            endpointConfigurator =>
            {
                endpointConfigurator.ConfigureConsumer<UserCreatedEventConsumer>(context);
            });

        configurator.ReceiveEndpoint(
            "work-management-user-avatar-changed",
            endpointConfigurator =>
            {
                endpointConfigurator.ConfigureConsumer<UserAvatarChangedEventConsumer>(context);
            });
    });
});

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "TeamworkSystem.Core.API",
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

app.Run();
