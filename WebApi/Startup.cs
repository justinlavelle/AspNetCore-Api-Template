using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using HC.Template.Domain.Models.Config;
using Microsoft.Extensions.Options;

namespace WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // This will push telemetry data through Application Insights 
                // pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            // Add SwaggerUI to the API
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Web API", Version = "v1" });
            });

            // **** Make appsettings.json available globally: ***********************************************

            // Add functionality to inject IOptions<T>
            services.AddOptions();

            // Add our Config object(s) so it can be injected
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<ConfigSettings>(Configuration.GetSection("ConfigSettings"));
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));

            services.AddScoped(cfg => cfg.GetService<IOptionsSnapshot<AppSettings>>().Value);
            services.AddScoped(cfg => cfg.GetService<IOptionsSnapshot<ConfigSettings>>().Value);
            services.AddScoped(cfg => cfg.GetService<IOptionsSnapshot<ConnectionStrings>>().Value);

            // *If* you need access to generic IConfiguration this is **required**
            services.AddSingleton(Configuration);   // IConfigurationRoot
            services.AddSingleton<IConfiguration>(Configuration);   // IConfiguration explicitly
            // **** appsettings.json END **********************************************************************

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // Add Logging
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error"); // specify a specific error page.
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {   // Creates a default route where route is not added to controller method.
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }

    }
}
