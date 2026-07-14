using Microsoft.EntityFrameworkCore.Metadata;
using OrderService.Models;
using OrderService.Services.interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace OrderService.Services
{
    public class RabbitMqPublisher : IRabbitMqPublisher
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqPublisher(IConnection connection)
        {
            _connection = connection;
        }

        public async Task Publish<T>(string queueName, T message)
        {
            using var channel = await _connection.CreateChannelAsync();

            await channel.QueueDeclareAsync
            (
                queue: queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );


            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            var properties = new BasicProperties();
            properties.Persistent = false;

            await channel.BasicPublishAsync
            (
                exchange: string.Empty,
                routingKey: queueName,//change this
                mandatory: false,
                basicProperties: properties,
                body: new ReadOnlyMemory<byte>(body)
            );
        }

    }

}
