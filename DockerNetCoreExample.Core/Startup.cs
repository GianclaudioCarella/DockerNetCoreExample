using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DockerNetCoreExample.Business.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DockerNetCoreExample
{
    public class Startup
    {
        private readonly IHostingEnvironment _environment;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            _environment = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // SERVICES
            services.AddTransient<QuoteService, QuoteService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            if (_environment.IsDevelopment())
            {             // Register the Swagger generator, defining 1 or more Swagger documents
                services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                    {
                        Title = "Docker NetCore Example",
                        Version = "v1",
                        Description = "API Documentation",
                    });
                });
            }


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            if (env.IsDevelopment())
            {
                #region SWAGGER CONFIGURATION

                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DockerNetCoreExample");
                });

                #endregion  SWAGGER CONFIGURATION
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
