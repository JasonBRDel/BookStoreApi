using Microsoft.EntityFrameworkCore;
using OrderService.Models.Repositories;

namespace OrderService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Order> Order { get; set; }
        public DbSet<Book> Book { get; set; }

    }
}
