using ChatApp.Consumer.Services;
using ChatApp.Domain.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Consumer
{
    public class ChatConsumer : IChatConsumer
    {
        private readonly string _hostname = "localhost";
        private readonly string _queueName = "test-queue";
        private IConnection _connection;
        private IModel channel;
        private readonly IAgentService _agentService;
        private string consumerTag;

        public ChatConsumer(IAgentService agentService)
        {
            _agentService = agentService;
        }

        public void ConsumeChat(Team team)
        {
            if (ConnectionExists())
            {
                using (channel = _connection.CreateModel())
                {
                    channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        consumerTag =  ea.ConsumerTag;
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine("[x] Received {0}", message);

                        bool isAssigned = _agentService.AssignChat(team, message).Result;

                        if (isAssigned)
                        {
                            channel.BasicAck(ea.DeliveryTag, false);
                        }
                    };
                    channel.BasicConsume(queue: _queueName,
                                         autoAck: false,
                                         consumer: consumer);

                    Console.WriteLine("Connection established");
                    Console.ReadLine();
                }
            }
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostname,
                };

                _connection = factory.CreateConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not create connection: {ex.Message}");
            }
        }

        private bool ConnectionExists()
        {
            if (_connection != null)
            {
                return true;
            }

            CreateConnection();

            return _connection != null;
        }
    }
}
