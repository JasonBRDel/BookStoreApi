using InventoryService.Models;
using MediatR;

namespace InventoryService.Features.Commands.DeleteBookCommand
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, BaseResponse<bool>>
    {
        public Task<BaseResponse<bool>> Handle(DeleteBookCommand cmd, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
