using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using UserStories.Models;
using UserStories.Services;
using Task = UserStories.Models.Task;

namespace UserStories
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddSingleton<ProgrammerService, ProgrammerService>();
            services.AddTransient<DbService<Programmer>>();
            services.AddTransient<DbService<Card>>();
            services.AddTransient<DbService<Fix>>();
            services.AddTransient<DbService<UserStory>>();
            services.AddTransient<DbService<Task>>();

            services.AddSingleton<CardService, CardService>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();
            services.AddMvc()
                .AddRazorPagesOptions(options =>
                    {
                        options.Conventions.AuthorizeFolder("/Account");
                        options.Conventions.AuthorizeFolder("/Admin");
                        options.Conventions.AuthorizeFolder("/Backlog");
                        options.Conventions.AuthorizeFolder("/Fixes");
                        options.Conventions.AuthorizeFolder("/UserStories");

                        options.Conventions.AllowAnonymousToPage("/Account/Login");
                        options.Conventions.AllowAnonymousToPage("/Account/Register");
                        options.Conventions.AllowAnonymousToPage("/Account/Logout");
                    }
                );

            services.AddDbContext<UserStoriesDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
