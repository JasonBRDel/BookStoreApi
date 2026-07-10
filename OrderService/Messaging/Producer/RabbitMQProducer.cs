using Newtonsoft.Json;
using OrderService.Messaging.Interfaces;
using RabbitMQ.Client;
using System.Text;


namespace OrderService.Messaging.Producer
{
    //public class RabbitMQProducer : IMessageProducer
    //{
    //    public void SendMessage<T>(T message)
    //    {
    //        var factory = new ConnectionFactory { HostName = "localhost" };
    //        using var connection = factory.CreateConnectionAsync();
    //        using var channel = connection.CreateModel();

    //        channel.QueueDeclare("orders", durable: true, exclusive: false, autoDelete: false);

    //        var json = JsonConvert.SerializeObject(message);
    //        var body = Encoding.UTF8.GetBytes(json);

    //        channel.BasicPublish(exchange: "", routingKey: "orders", basicProperties: null, body: body);
    //    }
    //}
}
