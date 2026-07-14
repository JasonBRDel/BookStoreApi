using Newtonsoft.Json;
using OrderService.Models;
using OrderService.Repositories.Interfaces;
using RabbitMQ.Client;
using System.Text;

namespace OrderService.Repositories
{
    public class GenericRabbitMQRepository<T> : IGenericRabbitMQRepository<T> where T : class
    {
        public async Task<string> PublishAsync(T item, MessageBus messageBus)
        {
            var factory = new ConnectionFactory 
            { 
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest",
                VirtualHost = "bookstore_vhost"
            };

            using var connection = await factory.CreateConnectionAsync();

            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync
                (
                    queue: messageBus.QueueName,
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

            var json = JsonConvert.SerializeObject(item);
            var body = Encoding.UTF8.GetBytes(json);

            var properties = new BasicProperties();
            properties.Persistent = false;

            await channel.BasicPublishAsync
                (
                    exchange: string.Empty,
                    routingKey: messageBus.QueueName,
                    mandatory: false,
                    basicProperties: properties,
                    body: new ReadOnlyMemory<byte>(body)
                );

            return $"Processed item of type {typeof(T).Name}: {item}";
        }
    }
}
