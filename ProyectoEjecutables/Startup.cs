using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ProyectoEjecutables.Repositories;
using Microsoft.EntityFrameworkCore;
using ProyectoEjecutables.Helpers;
using ProyectoEjecutables.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ProyectoEjecutables
{
    public class Startup
    {
        IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration) 
        {
            this.Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // TEMPDATA
            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            services.AddSession();
            services.AddMemoryCache();

            // AUTHENTICATION
            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie();

            // SQL SERVER
            String cadenasql = this.Configuration.GetConnectionString("sqlcasa");
            services.AddDbContext<EjecutablesContext>
                (options => options.UseSqlServer(cadenasql));
            services.AddTransient<IRepositoryEjecutables, RepositoryEjecutablesSQL>();

            services.AddTransient<PathProvider>();

            services.AddDistributedMemoryCache();
            //services.AddSession( options => {
            //    options.IdleTimeout = TimeSpan.FromMinutes(15);
            //});

            services.AddControllersWithViews
                (options => options.EnableEndpointRouting = false)//;
                .AddSessionStateTempDataProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseSession();
            app.UseMvc( routes => 
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
