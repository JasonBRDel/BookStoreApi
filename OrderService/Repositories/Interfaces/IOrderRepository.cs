using OrderService.Models.Repositories;
namespace OrderService.Repositories.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<string> CreateOrder(Order newOrder);
        Task<IEnumerable<Order>> GetOrders();
    }
}
