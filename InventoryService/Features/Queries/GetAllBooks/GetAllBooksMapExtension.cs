using InventoryService.Models.Repositories;

namespace InventoryService.Features.Queries.GetAllBooks
{
    public static class GetAllBooksMapExtension
    {
        public static GetAllBooksDto ToDto(this Book book)
        {
            return new (
                book.Id, 
                book.Title, 
                book.Author,
                book.Price,
                book.Inventory
                );
        }

        //public static GetAllBooksDto? ToListDto(this List<GetAllBooksBaseDto> baseDtoList)
        //{
        //    return new(baseDtoList);
        //}
    }
}
