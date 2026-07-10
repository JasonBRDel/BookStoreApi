using InventoryService.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Book { get; set;  }
    }
}
