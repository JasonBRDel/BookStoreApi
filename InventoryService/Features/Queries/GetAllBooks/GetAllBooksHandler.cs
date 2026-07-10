using InventoryService.Helpers;
using InventoryService.Models;
using InventoryService.Models.Repositories;
using InventoryService.Repositories.interfaces;
using MediatR;

namespace InventoryService.Features.Queries.GetAllBooks
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, BaseResponse<IEnumerable<Book>>>
    {
        private readonly IBookRepository _bookRepository;

        public GetAllBooksHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BaseResponse<IEnumerable<Book>>> Handle(GetAllBooksQuery query, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetBooks();
            return ResponseHelper.Ok(books);
        }
    }
}
