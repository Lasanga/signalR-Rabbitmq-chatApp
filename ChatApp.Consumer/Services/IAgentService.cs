using ChatApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Consumer.Services
{
    public interface IAgentService
    {
        Task<bool> AssignChat(Team team, string connectionId);
    }
}
