using MediatR;
using OrderService.Helpers;
using OrderService.Models;
using OrderService.Repositories.Interfaces;

namespace OrderService.Features.Coomands.DeleteOrder
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, BaseResponse<bool>>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteOrderCommand cmd, CancellationToken cancellationToken)
        {
            var res = await _orderRepository.DeleteOrder(cmd.OrderId, cancellationToken);
            return ResponseHelper.Ok(res);
        }
    }
}
