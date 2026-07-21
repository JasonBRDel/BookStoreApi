using MediatR;
using OrderService.Models;

namespace OrderService.Features.Coomands.DeleteOrder
{
    public record DeleteOrderCommand(int OrderId) : IRequest<BaseResponse<bool>>;
}
