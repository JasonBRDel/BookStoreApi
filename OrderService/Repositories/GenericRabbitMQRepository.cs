using Newtonsoft.Json;
using OrderService.Models;
using OrderService.Repositories.Interfaces;
using RabbitMQ.Client;
using System.Text;

namespace OrderService.Repositories
{
    public class GenericRabbitMQRepository<T> : IGenericRabbitMQRepository<T> where T : class
    {
        public async Task<string> PublishAsync(T item, MessageBus messageBus, CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest",
                VirtualHost = "bookstore_vhost"
            };

            using var connection = await factory.CreateConnectionAsync(cancellationToken);

            using var channel = await connection.CreateChannelAsync();

            await channel.ExchangeDeclareAsync
             (
                 exchange: messageBus.Exchange,
                 type: ExchangeType.Topic,
                 durable: true,
                 autoDelete: false,
                 arguments: null,
                 cancellationToken: cancellationToken
             );

            var json = JsonConvert.SerializeObject(item);
            var body = Encoding.UTF8.GetBytes(json);

            var properties = new BasicProperties
            {
                Persistent = false
            };

            await channel.BasicPublishAsync
                (
                    exchange: messageBus.Exchange,
                    routingKey: messageBus.RoutingKey,
                    mandatory: false,
                    basicProperties: properties,
                    body: new ReadOnlyMemory<byte>(body),
                    cancellationToken: cancellationToken
                );

            return $"Processed item of type {typeof(T).Name}: {item}";
        }
    }
}
