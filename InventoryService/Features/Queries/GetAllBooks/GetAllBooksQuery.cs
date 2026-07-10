using InventoryService.Models;
using InventoryService.Models.Repositories;
using MediatR;

namespace InventoryService.Features.Queries.GetAllBooks
{
    public record GetAllBooksQuery() : IRequest<BaseResponse<IEnumerable<Book>>>;
}
