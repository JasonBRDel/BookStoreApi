using System.ComponentModel.DataAnnotations.Schema;

namespace OrderService.Models.Repositories
{
    [Table("orders")]

    public class Order
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public DateTime OrderDate {  get; set; }
        public int Quantity { get; set; }
        public Book Book { get; set; }
    }
}
