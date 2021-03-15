using ChatApp.Consumer.Services;
using ChatApp.Infastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ChatApp.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {

            CreateHostBuilder(args).Build().Run();

        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    services.AddHostedService<ConsumerHostedService>();
                    services.AddSingleton<IChatConsumer, ChatConsumer>();
                    services.AddSingleton<IAgentService, AgentService>();
                    services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
                });
    }
}
