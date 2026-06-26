namespace InventoryService.Features.Commands.AddBookCommand
{
    public record AddBookRequest
    (
        string Name,
        int Price
    );
}
