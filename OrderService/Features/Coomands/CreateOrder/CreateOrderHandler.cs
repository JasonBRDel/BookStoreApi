using MediatR;
using OrderService.Helpers;
using OrderService.Models;
using OrderService.Models.Repositories;
using OrderService.Repositories.Interfaces;

namespace OrderService.Features.Coomands.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, BaseResponse<bool>>
    {        
        private readonly IOrderRepository _orderRepository;

        public CreateOrderHandler(IOrderRepository orderRepository)
        {          
            _orderRepository = orderRepository;
        }

        public async Task<BaseResponse<bool>> Handle(CreateOrderCommand cmd, CancellationToken cancellationToken)
        {
            var orderDto = new Order()
            {
                BookId = cmd.Request.BookId,
                Inventory = cmd.Request.Inventory
            };

            var res = await _orderRepository.CreateOrder(orderDto);
            return ResponseHelper.Ok(true);
        }
    }
}
