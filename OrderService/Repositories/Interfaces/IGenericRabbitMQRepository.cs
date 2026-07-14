using OrderService.Models;

namespace OrderService.Repositories.Interfaces
{
    public interface IGenericRabbitMQRepository<T> where T : class
    {
        Task<string> PublishAsync(T item, MessageBus message);

    }
}
