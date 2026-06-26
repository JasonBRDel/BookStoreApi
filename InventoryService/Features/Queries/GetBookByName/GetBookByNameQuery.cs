using InventoryService.Data;
using MediatR;

namespace InventoryService.Features.Queries.GetBookByName
{
    public record GetBookByNameQuery(string Name) : IRequest<BaseResponse<GetBookByNameDto>>;    
}
