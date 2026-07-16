using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Models;
using OrderService.Models.Repositories;
using OrderService.Repositories.Interfaces;

namespace OrderService.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly AppDbContext _context;
        private readonly IGenericRabbitMQRepository<Order> _genericRabbitMQRepository;
        private readonly MessageBus _bus;
        public OrderRepository(AppDbContext context, IGenericRabbitMQRepository<Order> genericRabbitMQRepository) : base(context)
        {
            _context = context;
            _genericRabbitMQRepository = genericRabbitMQRepository;
            _bus = new MessageBus
            {
                RoutingKey = "order.placed",
                Exchange = "bookstore_exchange"
            };
        }

        public async Task<string> CreateOrder(Order newOrder)
        {
            var res = await _genericRabbitMQRepository.PublishAsync(newOrder, _bus);
            return res;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _context.Order.Include(i => i.Book).ToListAsync();
        }

        //CRUD
    }
}
