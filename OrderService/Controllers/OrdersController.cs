using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderService.Features.Coomands.CreateOrder;
using OrderService.Features.Coomands.DeleteOrder;
using OrderService.Features.Coomands.UpdateOrder;
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

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOrder([FromRoute][Required] int id)
        {
            var response = await _mediator.Send(new DeleteOrderCommand(id));
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOrder([FromRoute][Required] int id)
        {
            var response = await _mediator.Send(new UpdateOrderCommand(id));
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
