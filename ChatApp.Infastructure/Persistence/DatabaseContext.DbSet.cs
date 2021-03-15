using ChatApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infastructure.Persistence
{
    public partial class DatabaseContext: DbContext
    {
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<AgentChat> AgentChats { get; set; }
    }
}
