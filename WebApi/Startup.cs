using HC.Template.Factories;
using HC.Template.Factories.Contracts;
using HC.Template.Infrastructure.ConfigModels;
using HC.Template.Infrastructure.Repositories.HealthCheck.Contracts;
using HC.Template.Infrastructure.Repositories.HealthCheck.Repo;
using HC.Template.Infrastructure.UOWs;
using HC.Template.Infrastructure.UOWs.Contracts;
using HC.Template.Interface.Contracts;
using HC.Template.InternalServices.ConfigurationService;
using HC.Template.InternalServices.ConfigurationService.Contracts;
using HC.Template.InternalServices.Mappers;
using HC.Template.InternalServices.Mappers.Contracts;
using HC.Template.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
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
            var pathToDoc = Configuration["Swagger:FileName"];
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Web API", Version = "v1" });
            });

            // **** Make appsettings.json available globally: ***********************************************

            // Add functionality to inject IOptions<T>
            services.AddOptions();

            // Add our Config object(s) so it can be injected [Dependency Injection]
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<ConfigSettings>(Configuration.GetSection("ConfigSettings"));
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            services.Configure<ExternalServices>(Configuration.GetSection("ExternalServices"));

            services.AddScoped(cfg => cfg.GetService<IOptionsSnapshot<AppSettings>>().Value);
            services.AddScoped(cfg => cfg.GetService<IOptionsSnapshot<ConfigSettings>>().Value);
            services.AddScoped(cfg => cfg.GetService<IOptionsSnapshot<ConnectionStrings>>().Value);
            services.AddScoped(cfg => cfg.GetService<IOptionsSnapshot<ExternalServices>>().Value);

            // *If* you need access to generic IConfiguration this is **required**
            services.AddSingleton(Configuration);   // IConfigurationRoot
            services.AddSingleton<IConfiguration>(Configuration);   // IConfiguration explicitly

            // Dependency injection for our repos and services [i.e. Data Layer to Core/logic Layer]

            // Dependency injection - 'Core' Services
            services.AddTransient<IExampleService, ExampleService>();
            services.AddTransient<ITestDBService, TestDBService>();

            // Dependency injection - 'Repo' Repositories
            // services.AddTransient<ITestRepo, TestRepo>(); // Removed because Unit of Work creates an instance of this.

            //services.AddTransient<IUnitOfWork, UnitOfWork>(); // Not sure if this is necessary

            // Dependency injection - Internal Services
            services.AddTransient<IConfigService, ConfigService>();

            // Dependency injection - Internal Services - Factories
            services.AddTransient<IUowFactory, UowFactory>();

            // Dependency injection - Internal Services - Mappers
            services.AddTransient<IExampleServiceMapper, ExampleServiceMapper>();
            services.AddTransient<ITestServiceMapper, TestServiceMapper>();
            services.AddTransient<IConfigServiceMapper, ConfigServiceMapper>();


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
