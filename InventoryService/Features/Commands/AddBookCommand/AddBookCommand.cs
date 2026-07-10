using InventoryService.Models;
using MediatR;

namespace InventoryService.Features.Commands.AddBookCommand
{
    public record AddBookCommand(AddBookRequest request) : IRequest<BaseResponse<bool>>;
}
