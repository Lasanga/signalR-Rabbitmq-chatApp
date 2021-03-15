using ChatApp.Domain.Models;
using ChatApp.Infastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp.Consumer
{
    public class ConsumerHostedService : IHostedService
    {
        private static Team currentTeam;
        private IChatConsumer _chatConsumer;
        private DatabaseContext _context;

        public ConsumerHostedService(
            IChatConsumer chatConsumer,
            DatabaseContext context)
        {
            _chatConsumer = chatConsumer;
            _context = context;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine();
            var teams = await _context.Teams.Include(x => x.Agents).ThenInclude(x => x.AgentChats).ToListAsync();
            teams.ForEach(x => Console.WriteLine($"{x.Id} - {x.TeamName}"));

            Console.WriteLine("\nPlease enter a team Id from the above list \n");
            var selectedId = Console.ReadLine();
            currentTeam = teams.FirstOrDefault(x => x.Id == int.Parse(selectedId));

            if (currentTeam == null)
            {
                Console.WriteLine($"\nPlease try again with a valid team id");
                return;
            }

            Console.WriteLine($"\nSelected Team name: {currentTeam.TeamName}");

            _chatConsumer.ConsumeChat(currentTeam);

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
