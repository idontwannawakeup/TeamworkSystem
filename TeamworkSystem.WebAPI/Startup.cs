using System;
using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
using TeamworkSystem.DataAccessLayer.Interfaces;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;

namespace TeamworkSystem.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime.
        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TeamworkSystemContext>(options =>
            {
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            services.AddTransient<IProjectsRepository, ProjectsRepository>();
            services.AddTransient<IRatingsRepository, RatingsRepository>();
            services.AddTransient<ITeamsRepository, TeamsRepository>();
            services.AddTransient<ITicketsRepository, TicketsRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IProjectsService, ProjectsService>();
            services.AddTransient<IRatingsService, RatingsService>();
            services.AddTransient<ITeamsService, TeamsService>();
            services.AddTransient<ITicketsService, TicketsService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IIdentityService, IdentityService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<JwtTokenConfiguration>();
            services.AddTransient<IJwtSecurityTokenFactory, JwtSecurityTokenFactory>();

            services.AddTransient<IValidatorFactory, ServiceProviderValidatorFactory>();
            services.AddMvc(options =>
                    {
                        options.EnableEndpointRouting = false;
                        options.Filters.Add<ValidationFilter>();
                    })
                    .AddFluentValidation(configuration =>
                    {
                        configuration.RegisterValidatorsFromAssemblies(
                            AppDomain.CurrentDomain.GetAssemblies());
                    });

            services.AddIdentityCore<User>()
                    .AddRoles<IdentityRole>()
                    .AddSignInManager<SignInManager<User>>()
                    .AddDefaultTokenProviders()
                    .AddEntityFrameworkStores<TeamworkSystemContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new()
                        {
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(Configuration["JwtSecurityKey"])),
                            ClockSkew = TimeSpan.Zero,
                        };
                    });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TeamworkSystem.WebAPI",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime.
        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint(
                    "/swagger/v1/swagger.json",
                    "TeamworkSystem.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
