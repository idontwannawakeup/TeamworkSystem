using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TeamworkSystem.BusinessLogicLayer.Configurations;
using TeamworkSystem.BusinessLogicLayer.Factories;
using TeamworkSystem.BusinessLogicLayer.Interfaces;
using TeamworkSystem.BusinessLogicLayer.Interfaces.Services;
using TeamworkSystem.BusinessLogicLayer.Services;
using TeamworkSystem.BusinessLogicLayer.Validation;
using TeamworkSystem.DataAccessLayer;
using TeamworkSystem.DataAccessLayer.Data;
using TeamworkSystem.DataAccessLayer.Data.Repositories;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Filters;
using TeamworkSystem.DataAccessLayer.Interfaces;
using TeamworkSystem.DataAccessLayer.Interfaces.Filters;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;
using TeamworkSystem.DataAccessLayer.Interfaces.Seeders;
using TeamworkSystem.DataAccessLayer.Seeders;
using TeamworkSystem.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddDbContext<TeamworkSystemContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

services.AddTransient<IProjectsRepository, ProjectsRepository>();
services.AddTransient<IRatingsRepository, RatingsRepository>();
services.AddTransient<ITeamsRepository, TeamsRepository>();
services.AddTransient<ITicketsRepository, TicketsRepository>();

services.AddTransient<IFilterCriteriaFactory, FilterCriteriaFactory>();

services.AddTransient<IFilterFactory<Project>, FilterFactory<Project>>();
services.AddTransient<IFilterFactory<Rating>, FilterFactory<Rating>>();
services.AddTransient<IFilterFactory<Team>, FilterFactory<Team>>();
services.AddTransient<IFilterFactory<Ticket>, FilterFactory<Ticket>>();
services.AddTransient<IFilterFactory<User>, FilterFactory<User>>();

services.AddTransient<IUnitOfWork, UnitOfWork>();

services.AddTransient<IIdentityService, IdentityService>();
services.AddTransient<IPhotosService, PhotosService>();
services.AddTransient<IProjectsService, ProjectsService>();
services.AddTransient<IRatingsService, RatingsService>();
services.AddTransient<ITeamsService, TeamsService>();
services.AddTransient<ITicketsService, TicketsService>();
services.AddTransient<IUsersService, UsersService>();

services.AddTransient<IProjectSeeder, ProjectSeeder>();
services.AddTransient<IRatingSeeder, RatingSeeder>();
services.AddTransient<ITeamSeeder, TeamSeeder>();
services.AddTransient<ITeamsMembersSeeder, TeamsMembersSeeder>();
services.AddTransient<ITicketSeeder, TicketSeeder>();
services.AddTransient<IUserSeeder, UserSeeder>();

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

services.AddTransient<JwtTokenConfiguration>();
services.AddTransient<IJwtSecurityTokenFactory, JwtSecurityTokenFactory>();

services.AddTransient<IValidatorFactory, ServiceProviderValidatorFactory>();

services.AddIdentityCore<User>()
        .AddRoles<IdentityRole>()
        .AddSignInManager<SignInManager<User>>()
        .AddDefaultTokenProviders()
        .AddEntityFrameworkStores<TeamworkSystemContext>();

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(builder.Configuration["JwtSecurityKey"])),
                ClockSkew = TimeSpan.Zero,
            };
        });

services.AddControllers()
        .AddFluentValidation(configuration =>
        {
            configuration
                .RegisterValidatorsFromAssemblyContaining<ValidationDependencyInjection>();
        });

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "TeamworkSystem.WebAPI",
            Version = "v1",
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
            Scheme = "Bearer",
        });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer",
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        },
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
