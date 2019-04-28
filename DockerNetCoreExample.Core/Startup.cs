using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DockerNetCoreExample.Business;
using DockerNetCoreExample.Business.Model;
using DockerNetCoreExample.Business.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            services.AddDbContext<ApiContext>(options =>
                options.UseInMemoryDatabase("InMemoryDatabase"));

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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, QuoteService quoteService)
        {
            // Creating mock data to EF In Memory
            List<Quote> quoteList = new List<Quote>(); ;
            quoteList.Add(new Quote() { Id = Guid.NewGuid(), Author = "Socrates", Sentence = "The unexamined life is not worth living." });
            quoteList.Add(new Quote() { Id = Guid.NewGuid(), Author = "Ludwig Wittgenstein", Sentence = "Whereof one cannot speak, thereof one must be silent" });
            quoteList.Add(new Quote() { Id = Guid.NewGuid(), Author = "William of Ockham", Sentence = "Entities should not be multiplied unnecessarily" });
            quoteList.Add(new Quote() { Id = Guid.NewGuid(), Author = "Thomas Hobbes", Sentence = "The life of man (in a state of nature) is solitary, poor, nasty, brutish, and short" });
            quoteList.Add(new Quote() { Id = Guid.NewGuid(), Author = "René Descartes", Sentence = "I think therefore I am" });
            quoteList.Add(new Quote() { Id = Guid.NewGuid(), Author = "Martin Heidegger", Sentence = "He who thinks great thoughts, often makes great errors" });
            quoteList.Add(new Quote() { Id = Guid.NewGuid(), Author = "Gottfried Wilhelm Leibniz", Sentence = "We live in the best of all possible world" });
            quoteList.Add(new Quote() { Id = Guid.NewGuid(), Author = "G.W.F.Hegel", Sentence = "What is rational is actual and what is actual is rational" });
            quoteList.Add(new Quote() { Id = Guid.NewGuid(), Author = "Albert Camus", Sentence = "There is but one truly serious philosophical problem, and that is suicide" });
            quoteList.Add(new Quote() { Id = Guid.NewGuid(), Author = "Heraclitus", Sentence = "One cannot step twice in the same river" });

            // Adding mock data to EF In Memory
            quoteService.AddRange(quoteList);

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
