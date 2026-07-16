using MediatR;
using OrderService.Models;
using OrderService.Models.Repositories;

namespace OrderService.Features.Queries.GetAllOrders
{
    public record GetAllOrdersQuery() : IRequest<BaseResponse<IEnumerable<Order>>>;
}
