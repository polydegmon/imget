using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using Imget.Models;

namespace Imget
{
    public class Startup
    {
        /// <summary>
        /// This is the object that contains all the configuration taken from the appSettings.json file
        /// This file has replaced the web.config
        /// </summary>
        public IConfigurationRoot Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="env">
        /// IHostingEnvironment
        /// Provides the current EnvironmentName, ContentRootPath, WebRootPath, and web root file provider. 
        /// Available to the Startup constructor and Configure method.
        /// </param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        /// <summary>
        /// Configure the services for the container
        /// 
        /// Add frameworks as services.
        /// </summary>
        /// <param name="services">
        /// IServiceCollection
        /// The current set of services configured in the container. 
        /// Available only to the ConfigureServices method, and used by that method to configure the services available to an application.
        /// 
        /// A collection of defined services for the application
        /// Add all services and frameworks required to this collection
        /// </param>
        /// <remarks>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        /// </remarks>
        public void ConfigureServices(IServiceCollection services)
        {
            // Get the HealthCheck section of the configuration file and turn it into the HealthCheckConfig object
            services.Configure<HealthCheckConfig>(Configuration.GetSection("ApplicationInformation"));
            
            // Add Application Insights Framework.
            services.AddApplicationInsightsTelemetry(Configuration);

            // Add the services required to run .Net MVC Framework
            services.AddMvc()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization();            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app">
        /// IApplicationBuilder
        /// Used to build the application request pipeline. 
        /// Available only to the Configure method in Startup. 
        /// Learn more about Request Features.
        /// </param>
        /// <param name="env">
        /// IHostingEnvironment
        /// Provides the current EnvironmentName, ContentRootPath, WebRootPath, and web root file provider. 
        /// Available to the Startup constructor and Configure method.
        /// </param>
        /// <param name="loggerFactory">
        /// ILoggerFactory
        /// Provides a mechanism for creating loggers.
        /// Available to the Startup constructor and Configure method.Learn more about Logging.
        /// </param>
        /// <remarks>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </remarks>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();
                        
            app.UseMvc();
        }
    }
}
