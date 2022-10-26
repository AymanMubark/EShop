using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.DTOs;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;

namespace Ordering.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("{username}")]
        public async Task<ActionResult<List<OrderResponseDTO>>> GetUserOrders(string username)
        {
            var query = new GetOrdersListQuery(username);
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult> AddOrder([FromBody] CheckoutOrderCommand model)
        {
            await _mediator.Send(model);
            return Ok();
        }

    }
}

