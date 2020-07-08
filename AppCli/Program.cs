using System;
using System.Threading.Tasks;
using AppCli.Commands.Candidate;
using AppShared.Entities;
using AppShared.Repositories;
using CliFx;
using Microsoft.Extensions.DependencyInjection;

namespace AppCli
{
    public static class Program
    {
        private static IServiceProvider GetServiceProvider()
        {
            // We use Microsoft.Extensions.DependencyInjection for injecting dependencies in commands
            var services = new ServiceCollection();

            // register the database context
            services.AddDbContext<EntityContext>();
            
            // register candidate repository
            services.AddSingleton<CandidateRepository>();
            services.AddTransient<CreateCandidate>();
            services.AddTransient<ListCandidates>();

            return services.BuildServiceProvider();
        }

        public static async Task<int> Main()
        {
            return await new CliApplicationBuilder()
                .AddCommandsFromThisAssembly()
                .UseTypeActivator(GetServiceProvider().GetService)
                .Build()
                .RunAsync();
        }
    }
}
