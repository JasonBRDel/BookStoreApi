using BookStoreWorkerService.Models;

namespace BookStoreWorkerService.DAL
{
    public interface IOrderRepository
    {
        Task CreateOrder(string createOrder, CancellationToken cancellationToken);
        //Task DeleteOrder(string deleteOrder, CancellationToken cancellationToken);
    }
}
