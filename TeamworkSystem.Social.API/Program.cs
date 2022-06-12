using MassTransit;
using Microsoft.OpenApi.Models;
using TeamworkSystem.Social.API.Consumers;
using TeamworkSystem.Social.API.DependencyInjection;
using TeamworkSystem.Social.API.Middlewares;
using TeamworkSystem.Social.BusinessLogic.DependencyInjection;
using TeamworkSystem.Social.DataAccess.DependencyInjection;

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
    configuration.AddConsumer<UserCreatedEventConsumer>();
    configuration.AddConsumer<UserAvatarChangedEventConsumer>();

    configuration.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host(builder.Configuration["EventBusSettings:HostAddress"]);
        configurator.ReceiveEndpoint(
            "social-user-created",
            endpointConfigurator =>
            {
                endpointConfigurator.ConfigureConsumer<UserCreatedEventConsumer>(context);
            });

        configurator.ReceiveEndpoint(
            "social-user-avatar-changed",
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
            Title = "TeamworkSystem.Social.API",
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

app.Run();
