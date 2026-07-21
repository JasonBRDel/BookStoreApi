namespace BookStoreWorkerService.Models
{
    public record CreateOrder(
            int BookId,
            DateTime OrderDate,
            int Quantity
        );
}
