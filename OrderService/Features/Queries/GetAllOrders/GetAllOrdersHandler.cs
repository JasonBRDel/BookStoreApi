using MediatR;
using OrderService.Helpers;
using OrderService.Models;
using OrderService.Models.Repositories;
using OrderService.Repositories.Interfaces;

namespace OrderService.Features.Queries.GetAllOrders
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, BaseResponse<IEnumerable<Order>>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllOrdersHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<BaseResponse<IEnumerable<Order>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrders(cancellationToken);
            return ResponseHelper.Ok(orders);
        }
    }
}
