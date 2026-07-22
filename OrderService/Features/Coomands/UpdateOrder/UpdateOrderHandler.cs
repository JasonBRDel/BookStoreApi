using MediatR;
using OrderService.Helpers;
using OrderService.Models;
using OrderService.Repositories.Interfaces;

namespace OrderService.Features.Coomands.UpdateOrder
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, BaseResponse<bool>>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateOrderCommand cmd, CancellationToken cancellationToken)
        {
            var res = await _orderRepository.UpdateOrder(cmd.Id, cancellationToken);
            return ResponseHelper.Ok(res);
        }
    }
}
