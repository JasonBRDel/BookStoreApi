using BookStoreWorkerService.Models;

namespace BookStoreWorkerService.DAL
{
    public interface IOrderRepository
    {
        Task CreateOrder(string createOrder, CancellationToken cancellationToken);
        Task CompleteOrder(string json, CancellationToken cancellationToken);
    }
}
