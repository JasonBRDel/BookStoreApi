namespace OrderService.Models
{
    public class MessageBus
    {
        public string RoutingKey { get; set; }
        public string Exchange { get; set; }
    }
}
