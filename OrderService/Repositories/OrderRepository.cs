using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Models;
using OrderService.Models.Repositories;
using OrderService.Repositories.Interfaces;

namespace OrderService.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IGenericRabbitMQRepository<Order> _genericRabbitMQRepository;
        private MessageBus _bus;
        public OrderRepository(AppDbContext context, IGenericRabbitMQRepository<Order> genericRabbitMQRepository) : base(context)
        {
            _dbContext = context;
            _genericRabbitMQRepository = genericRabbitMQRepository;
            _bus = new MessageBus
            {
                Exchange = "bookstore_exchange"
            };
        }

        public async Task<string> CreateOrder(Order newOrder, CancellationToken cancellationToken)
        {
            _bus.RoutingKey = "order.placed";
            var res = await _genericRabbitMQRepository.PublishAsync(newOrder, _bus, cancellationToken);
            return res;
        }

        public async Task<IEnumerable<Order>> GetOrders(CancellationToken cancellationToken)
        {
            return await _dbContext.Order.Include(i => i.Book).ToListAsync(cancellationToken);
        }

        public async Task<bool> DeleteOrder(int orderId, CancellationToken cancellationToken)
        {
            try
            {
                //_bus.RoutingKey = "order.cancelled";
                var orderToDelete = await _dbContext.Order
                    .AsNoTracking()
                    .FirstOrDefaultAsync(i => i.Id == orderId, cancellationToken);

                if (orderToDelete != null)
                {
                    _dbContext.Order.Remove(orderToDelete);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return true;
                }
                return false;
            }
            catch (Exception) { 
                return false;
            }
        }

        //CRUD
    }
}
