using InventoryService.Data;
using MediatR;

namespace InventoryService.Features.Commands.AddBookCommand
{
    public class AddBookHandler : IRequestHandler<AddBookCommand, BaseResponse<bool>>
    {
        public Task<BaseResponse<bool>> Handle(AddBookCommand cmd, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
