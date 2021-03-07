using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TeamworkSystem.DataAccessLayer.Data;
using TeamworkSystem.DataAccessLayer.Infrastructure;
using TeamworkSystem.DataAccessLayer.Interfaces;
using TeamworkSystem.DataAccessLayer.Models;

namespace TeamworkSystem.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime.
        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISqlConnectionFactory, SqlConnectionFactory>();

            services.AddTransient<IRepository<User, int>, UsersRepository>();
            services.AddTransient<IRepository<Team, int>, TeamsRepository>();
            services.AddTransient<IRepository<Project, int>, ProjectsRepository>();
            services.AddTransient<IRepository<Ticket, int>, TicketsRepository>();
            services.AddTransient<IRepository<Rating, (int, int)>, RatingsRepository>();

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
