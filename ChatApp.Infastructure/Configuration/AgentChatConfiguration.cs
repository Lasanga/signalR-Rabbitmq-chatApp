using ChatApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApp.Infastructure.Configuration
{
    public class AgentChatConfiguration : IEntityTypeConfiguration<AgentChat>
    {
        public void Configure(EntityTypeBuilder<AgentChat> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Agent)
                .WithMany(x => x.AgentChats)
                .HasForeignKey(x => x.AgentId);
        }
    }
}
