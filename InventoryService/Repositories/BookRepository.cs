using InventoryService.Data;
using InventoryService.Models.Repositories;
using InventoryService.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _context.Book.ToListAsync();
        }
    }
}
