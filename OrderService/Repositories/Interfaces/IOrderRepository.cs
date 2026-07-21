using OrderService.Models.Repositories;
namespace OrderService.Repositories.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<string> CreateOrder(Order newOrder, CancellationToken cancellationToken);
        Task<IEnumerable<Order>> GetOrders(CancellationToken cancellationToken);
        Task<bool> DeleteOrder(int OrderId, CancellationToken cancellationToken);
    }
}
