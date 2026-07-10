using InventoryService.Data;
using InventoryService.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

    }
}
