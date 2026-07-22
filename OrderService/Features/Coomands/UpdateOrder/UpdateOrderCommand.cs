using MediatR;
using OrderService.Models;

namespace OrderService.Features.Coomands.UpdateOrder
{
    public record UpdateOrderCommand(int Id) : IRequest<BaseResponse<bool>>;
}
