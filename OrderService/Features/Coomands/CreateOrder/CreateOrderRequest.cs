namespace OrderService.Features.Coomands.CreateOrder
{
    public record CreateOrderRequest
        (
            int BookId,            
            int Inventory
        );
}
