namespace InventoryService.Features.Queries.GetAllBooks
{
    //public record GetAllBooksDto
    //(
    //    List<GetAllBooksBaseDto> GetAllBooksListDtos
    //);

    public record GetAllBooksDto
     (
         int Id,
         string Title,
         string Author,
         double Price,
         int Inventory
     );
}
