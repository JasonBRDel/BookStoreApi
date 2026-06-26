using InventoryService.Data;
using MediatR;

namespace InventoryService.Features.Commands.DeleteBookCommand
{
    public record DeleteBookCommand(int Id) : IRequest<BaseResponse<bool>>;
}
