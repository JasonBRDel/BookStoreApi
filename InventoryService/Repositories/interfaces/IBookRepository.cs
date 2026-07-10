using InventoryService.Models.Repositories;

namespace InventoryService.Repositories.interfaces
{
    public interface IBookRepository:IGenericRepository<Book>
    {
        Task<IEnumerable<Book>> GetBooks();
        //add book
    }
}
