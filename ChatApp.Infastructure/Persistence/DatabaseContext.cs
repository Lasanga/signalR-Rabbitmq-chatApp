using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infastructure.Persistence
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Teams.AddRange(InMemoryData.GetTeams());
            SaveChanges();

            Agents.AddRange(InMemoryData.GetTeamAAgents());
            Agents.AddRange(InMemoryData.GetTeamBAgents());
            Agents.AddRange(InMemoryData.GetTeamCAgents());
            Agents.AddRange(InMemoryData.GetTeamOverflowAgents());
            Agents.AddRange(InMemoryData.GetTeamExampleAgents());
            SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        }
    }
}
