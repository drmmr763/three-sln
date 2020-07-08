using Microsoft.EntityFrameworkCore;

namespace AppShared.Entities
{
    public class EntityContext : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<CandidateJobMatch> CandidateJobMatches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(
                "Server=localhost,1433; Database=EntityApp;User=sa; Password=<YourStrong@Passw0rd>");
    }
}
