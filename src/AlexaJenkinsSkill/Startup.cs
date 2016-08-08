using AlexaJenkinsSkill.Lib.Clients;
using AlexaJenkinsSkill.Lib.Clients.Interfaces;
using AlexaJenkinsSkill.Lib.Handlers.Factories;
using AlexaJenkinsSkill.Lib.Handlers.Factories.Interfaces;
using AlexaJenkinsSkill.Lib.Options;
using AlexaJenkinsSkill.Lib.Speechlets;
using AlexaJenkinsSkill.Lib.Speechlets.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AlexaJenkinsSkill
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc()
                    .AddWebApiConventions(); // TODO: these are 'shim' conventions for backward compatibility with WebAPI 2. should remove this when skills kit is updated for .net core.
            services.AddOptions();
            services.AddLogging();

            // Add speechlet library services
            services.Configure<JenkinsOptions>(options => {
                options.JenkinsAuthenticationToken = Configuration["JenkinsAuthenticationToken"];
                options.JenkinsBaseUri = Configuration["JenkinsBaseUri"];
                options.JenkinsApiKey = Configuration["JenkinsApiKey"];
                options.JenkinsUserName = Configuration["JenkinsUserName"];
            });

            services.AddScoped<IJenkinsSpeechlet, JenkinsSpeechlet>();
            services.AddScoped<IIntentHandlerFactory, IntentHandlerFactory>();
            services.AddScoped<IJenkinsClient, JenkinsClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseMvc();
        }
    }
}
