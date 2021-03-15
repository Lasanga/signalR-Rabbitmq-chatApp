using ChatApp.Domain.Enums;
using System.Collections.Generic;

namespace ChatApp.Domain.Models
{
    public class Agent
    {
        public int Id { get; set; }
        public double Seniority { get; set; }
        public int TeamId { get; set; }
        public WorkShift WorkShift { get; set; }
        public virtual Team Team { get; set; }
        public ICollection<AgentChat> AgentChats { get; set; }
    }
}
