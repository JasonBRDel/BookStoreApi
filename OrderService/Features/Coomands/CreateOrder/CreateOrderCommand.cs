using MediatR;
using OrderService.Models;

namespace OrderService.Features.Coomands.CreateOrder
{
    public record CreateOrderCommand(CreateOrderRequest Request) : IRequest<BaseResponse<string>>;
}
