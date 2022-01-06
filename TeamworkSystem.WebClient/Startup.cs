using System.Globalization;
using Blazored.LocalStorage;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Localization;
using MudBlazor.Services;
using TeamworkSystem.WebClient.Authentication;
using TeamworkSystem.WebClient.Extensions;
using TeamworkSystem.WebClient.Interfaces;
using TeamworkSystem.WebClient.Services;

namespace TeamworkSystem.WebClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime.
        // Use this method to add services to the container.
        // For more information on how to configure your application,
        // visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddMudServices();
            services.AddBlazoredLocalStorage();
            services.AddAuthorizationCore();

            services.AddControllers();

            services.AddMvc()
                    .AddFluentValidation(configuration =>
                    {
                        configuration.RegisterValidatorsFromAssemblies(
                            AppDomain.CurrentDomain.GetAssemblies());
                    });

            services.AddTransient<RequestErrorsHandler>();

            services.AddScoped<AuthenticationStateProvider>(
                provider => provider.GetRequiredService<ApiAuthenticationStateProvider>());

            services.AddScoped<ApiAuthenticationStateProvider>();

            string apiUrl = Configuration["ApiUrl"];

            services.AddHttpClient<IIdentityService, IdentityService>(httpClient =>
            {
                httpClient.BaseAddress = new($"{apiUrl}/api/Identity/");
            });

            services.AddHttpClient<IProjectsService, ProjectsService>(httpClient =>
            {
                httpClient.BaseAddress = new($"{apiUrl}/api/Projects/");
            });

            services.AddHttpClient<IRatingsService, RatingsService>(httpClient =>
            {
                httpClient.BaseAddress = new($"{apiUrl}/api/Ratings/");
            });

            services.AddHttpClient<ITeamsService, TeamsService>(httpClient =>
            {
                httpClient.BaseAddress = new($"{apiUrl}/api/Teams/");
            });

            services.AddHttpClient<ITicketsService, TicketsService>(httpClient =>
            {
                httpClient.BaseAddress = new($"{apiUrl}/api/Tickets/");
            });

            services.AddHttpClient<IUsersService, UsersService>(httpClient =>
            {
                httpClient.BaseAddress = new($"{apiUrl}/api/Users/");
            });

            services.AddLocalization(options => options.ResourcesPath = "Localization");
            var supportedCultures = new List<CultureInfo>()
            {
                new CultureInfo("en-US"),
                new CultureInfo("uk-UA")
            };

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        }

        // This method gets called by the runtime.
        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days.
                // You may want to change this for production scenarios,
                // see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRequestLocalization();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
