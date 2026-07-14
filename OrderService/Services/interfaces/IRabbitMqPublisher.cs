namespace OrderService.Services.interfaces
{
    public interface IRabbitMqPublisher
    {
        Task Publish<T>(string queueName, T message);
    }
}
