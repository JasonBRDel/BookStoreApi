using InventoryService.Data;

namespace InventoryService.Features.Queries.GetBookByName
{
    public static class GetBookByNameMethods
    {
        public static GetBookByNameDto ToDto(Book book)
        {
            return new(
                book.Id,
                book.Name,
                book.Price
                );
        }
    }
}
