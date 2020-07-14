using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Options;

namespace AppShared.Entities
{
    public class EntityContext : DbContext
    {
        private DatabaseConfig _databaseConfig;
        
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<CandidateJobMatch> CandidateJobMatches { get; set; }

        public EntityContext(IOptionsSnapshot<DatabaseConfig> dbConfig)
        {
            _databaseConfig = dbConfig.Value ?? throw new ArgumentNullException(nameof(dbConfig));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = GetConnectionString();
            options.UseSqlServer(connectionString);
        }

        private string GetConnectionString()
        {
            return
                $"Server={_databaseConfig.Host},{_databaseConfig.Port}; Database={_databaseConfig.Schema}; User={_databaseConfig.Username}; Password={_databaseConfig.Password}";
        }
    }
    
    
}
