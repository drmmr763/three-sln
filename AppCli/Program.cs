using System;
using System.Threading.Tasks;
using AppCli.Commands.Candidate;
using AppShared;
using AppShared.Entities;
using AppShared.Repositories;
using CliFx;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.FeatureManagement;

namespace AppCli
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }
        
        private static IServiceProvider GetServiceProvider()
        {
            // We use Microsoft.Extensions.DependencyInjection for injecting dependencies in commands
            var services = new ServiceCollection();

            // Get the db config section
            var dbConfig = Configuration.GetSection("Database");

            // Write the config to the db class with injected values
            services.Configure<DatabaseConfig>(dbConfig);
                
            // register the database context
            services.AddDbContext<EntityContext>();
            
            // register candidate repository
            services.AddSingleton<CandidateRepository>();
            services.AddTransient<CreateCandidate>();
            services.AddTransient<ListCandidates>();
            
            // feature management
            services.AddOptions();
            services.AddFeatureManagement();
            
            return services.BuildServiceProvider();
        }

        public static async Task<int> Main(string[] args)
        {
            // set up a new configuration instance
            var config = new ConfigurationBuilder();
            
            // add user secrets to retrieve the azure app config endpoint
            config.AddUserSecrets<Program>();
            
            // build the config, load azure app config and then set the build config builder for DI
            var settings = config.Build();
            var result   = config.AddAzureAppConfiguration(settings["ConnectionStrings:ApiAppConfig"]).Build();
            
            Configuration = result;
            
            return await new CliApplicationBuilder()
                .AddCommandsFromThisAssembly()
                .UseTypeActivator(GetServiceProvider().GetService)
                .Build()
                .RunAsync();
        }
    }
}
