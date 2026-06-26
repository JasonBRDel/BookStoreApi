using InventoryService.Data;
using MediatR;

namespace InventoryService.Features.Queries.GetAllBooks
{
    public record GetAllBooksQuery() : IRequest<BaseResponse<GetAllBooksDto>>;
}
