
using InventoryService.Features.Commands.AddBookCommand;
using InventoryService.Features.Commands.DeleteBookCommand;
using InventoryService.Features.Commands.UpdateBookCommand;
using InventoryService.Features.Queries.GetAllBooks;
using InventoryService.Features.Queries.GetBookByName;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace InventoryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllBooks()
        {
            var response = await _mediator.Send(new GetAllBooksQuery());
            return response.Success ? Ok(response) : BadRequest(response);            
        }

        [HttpGet(Name = "BookByName")]
        public async Task<IActionResult> GetBookByName([FromQuery][Required]string name)
        {
            var response = await _mediator.Send(new GetBookByNameQuery(name));
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost(Name = "AddBook")]
        public async Task<IActionResult> AddBook([FromBody][Required]AddBookRequest request)
        {
            var response = await _mediator.Send(new AddBookCommand(request));
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete(Name = "RemoveBook/{id}")]
        public async Task<IActionResult> RemoveBook([FromRoute][Required] int id)
        {
            var response = await _mediator.Send(new DeleteBookCommand(id));
            return response.Success ? Ok(response) : BadRequest(response);
        }


        [HttpPut(Name = "UpdateBook")]
        public async Task<IActionResult> UpdateBook([FromBody][Required] UpdateBookRequest request)
        {
            var response = await _mediator.Send(new UpdateBookCommand(request));
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("test")]
        public async Task<IActionResult> TestBooks()
        {
            return Ok(new { message = "This is book api", user = User.Identity?.Name });
        }

        [HttpGet("test2")]
        [Authorize]
        public async Task<IActionResult> TestBooks2()
        {
            return Ok(new { message = "This is book api 2", user = User.Identity?.Name });
        }
    }
}
