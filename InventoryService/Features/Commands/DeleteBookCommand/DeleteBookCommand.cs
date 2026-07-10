using InventoryService.Models;
using MediatR;

namespace InventoryService.Features.Commands.DeleteBookCommand
{
    public record DeleteBookCommand(int Id) : IRequest<BaseResponse<bool>>;
}
