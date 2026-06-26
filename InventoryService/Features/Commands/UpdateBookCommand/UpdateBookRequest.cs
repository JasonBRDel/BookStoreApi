namespace InventoryService.Features.Commands.UpdateBookCommand
{
    public record UpdateBookRequest
    (
        int Id,
        string Name,
        int Price
    );
}
