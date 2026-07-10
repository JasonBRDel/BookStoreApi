using Microsoft.AspNetCore.Mvc;
using OrderService.Messaging.Interfaces;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMessageProducer _producer;
        public OrdersController(IMessageProducer producer)
        {
            _producer = producer;
        }

        //[HttpPost]
        //public IActionResult CreateOrder(OrderDto order)
        //{
        //    _producer.SendMessage(order);
        //    return Ok(new { Status = "Order Sent" });
        //}
    }
}
