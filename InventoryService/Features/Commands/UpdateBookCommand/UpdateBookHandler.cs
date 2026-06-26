using InventoryService.Data;
using MediatR;

namespace InventoryService.Features.Commands.UpdateBookCommand
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, BaseResponse<bool>>
    {
        public Task<BaseResponse<bool>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
