using InventoryService.Models;
using MediatR;

namespace InventoryService.Features.Queries.GetBookByName
{
    public class GetBookByNameHandler : IRequestHandler<GetBookByNameQuery, BaseResponse<GetBookByNameDto>>
    {


        public Task<BaseResponse<GetBookByNameDto>> Handle(GetBookByNameQuery query, CancellationToken cancellationToken)
        {
            
            throw new NotImplementedException();
        }
    }
}
