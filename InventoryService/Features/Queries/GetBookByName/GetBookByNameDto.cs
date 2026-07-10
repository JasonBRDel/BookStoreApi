namespace InventoryService.Features.Queries.GetBookByName
{
    public record GetBookByNameDto
    (
        int Id,
        string Title,
        string Author,
        double Price,
        int Inventory
    );
}
