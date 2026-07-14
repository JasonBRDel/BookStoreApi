using System.ComponentModel.DataAnnotations.Schema;

namespace OrderService.Models.Repositories
{
    [Table("orders")]

    public class Order
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Inventory { get; set; }
    }
}
