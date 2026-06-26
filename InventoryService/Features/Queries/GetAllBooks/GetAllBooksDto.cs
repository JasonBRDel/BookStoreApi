namespace InventoryService.Features.Queries.GetAllBooks
{
    public record GetAllBooksDto
    (
        List<GetAllBooksBaseDto> GetAllBooksListDtos
    );

    public record GetAllBooksBaseDto
     (
         int Id,
         string Name,
         int Price
     );
}
