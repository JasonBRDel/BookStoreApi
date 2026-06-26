using InventoryService.Data;
using MediatR;

namespace InventoryService.Features.Queries.GetAllBooks
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, BaseResponse<GetAllBooksDto>>
    {
        public Task<BaseResponse<GetAllBooksDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
