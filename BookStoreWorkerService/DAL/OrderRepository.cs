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

        //public async Task DeleteOrder(string json, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        JsonSerializerOptions options = new()
        //        {
        //            PropertyNameCaseInsensitive = true
        //        };

        //        int id = JsonSerializer.Deserialize<int>(json, options);

        //        if (string.IsNullOrEmpty(id.ToString()))
        //        {
        //            Console.WriteLine("Failed to parse JSON: result is null.");
        //            return;
        //        }

        //        await _appDbContext.order
        //    }
        //    catch (JsonException ex)
        //    {
        //        Console.WriteLine($"Invalid JSON: {ex.Message}");
        //    }
        //}
    }
}
