using BookStoreWorkerService.Data;
using BookStoreWorkerService.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BookStoreWorkerService.DAL
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task CompleteOrder(string json, CancellationToken cancellationToken)
        {
            try
            {
                JsonSerializerOptions options = new()
                {
                    PropertyNameCaseInsensitive = true
                };

                CompleteOrder? completeOrder = JsonSerializer.Deserialize<CompleteOrder>(json, options);

                if (completeOrder is null)
                {
                    Console.WriteLine("Failed to parse JSON: result is null.");
                    return;
                }

                await _appDbContext.Database
                    .ExecuteSqlInterpolatedAsync($"EXEC uspCompleteOrder {completeOrder.id}", cancellationToken);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Invalid JSON: {ex.Message}");
            }
        }

        public async Task CreateOrder(string json, CancellationToken cancellationToken)
        {
            try
            {
                JsonSerializerOptions options = new()
                {
                    PropertyNameCaseInsensitive = true
                };

                CreateOrder? createOrder = JsonSerializer.Deserialize<CreateOrder>(json, options);

                if (createOrder is null)
                {
                    Console.WriteLine("Failed to parse JSON: result is null.");
                    return;
                }

                await _appDbContext.Database
                    .ExecuteSqlInterpolatedAsync($"EXEC uspCreateOrder {createOrder.BookId}, {createOrder.OrderDate}, {createOrder.Quantity}", cancellationToken);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Invalid JSON: {ex.Message}");
            }
        }



    }
}
