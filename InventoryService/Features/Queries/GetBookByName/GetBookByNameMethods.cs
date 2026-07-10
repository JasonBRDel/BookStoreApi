using InventoryService.Models.Repositories;

namespace InventoryService.Features.Queries.GetBookByName
{
    public static class GetBookByNameMethods
    {
        public static GetBookByNameDto ToDto(Book book)
        {
            return new(
                book.Id,
                book.Title,
                book.Author,
                book.Price,
                book.Inventory
                );
        }
    }
}
