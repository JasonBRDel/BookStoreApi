using MediatR;
using OrderService.Helpers;
using OrderService.Models;
using OrderService.Models.Repositories;
using OrderService.Repositories.Interfaces;

namespace OrderService.Features.Coomands.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, BaseResponse<string>>
    {        
        private readonly IOrderRepository _orderRepository;

        public CreateOrderHandler(IOrderRepository orderRepository)
        {          
            _orderRepository = orderRepository;
        }

        public async Task<BaseResponse<string>> Handle(CreateOrderCommand cmd, CancellationToken cancellationToken)
        {
            var orderDto = new Order()
            {
                BookId = cmd.Request.BookId,
                Quantity = cmd.Request.Quantity,
                OrderDate = DateTime.Now
            };

            var res = await _orderRepository.CreateOrder(orderDto);
            return ResponseHelper.Ok(res);
        }
    }
}
