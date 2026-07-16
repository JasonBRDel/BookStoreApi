using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderService.Features.Coomands.CreateOrder;
using OrderService.Features.Queries.GetAllOrders;
using System.ComponentModel.DataAnnotations;
namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var response = await _mediator.Send(new GetAllOrdersQuery());
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody][Required]CreateOrderRequest request)
        {
            var response = await _mediator.Send(new CreateOrderCommand(request));
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
