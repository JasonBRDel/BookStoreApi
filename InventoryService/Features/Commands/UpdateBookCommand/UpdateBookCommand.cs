using InventoryService.Data;
using MediatR;

namespace InventoryService.Features.Commands.UpdateBookCommand
{
    public record UpdateBookCommand(UpdateBookRequest Request) : IRequest<BaseResponse<bool>>;  
}
