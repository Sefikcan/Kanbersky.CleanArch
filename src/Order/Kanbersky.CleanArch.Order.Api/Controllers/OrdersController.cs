using Kanbersky.CleanArch.Core.Results.ApiResponses.Concrete;
using Kanbersky.CleanArch.Order.Services.Commands;
using Kanbersky.CleanArch.Order.Services.DTO.Response;
using Kanbersky.CleanArch.Order.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kanbersky.CleanArch.Order.Api.Controllers
{
    [Route("api/v1/orders")]
    [ApiController]
    public class OrdersController : CleanArchControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("userName")]
        [ProducesResponseType(typeof(IEnumerable<OrderResponseModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrdersByUserName([FromQuery] string userName)
        {
            var query = new GetOrderByUserNameQuery(userName);
            var orders = await _mediator.Send(query);
            return ApiOk(orders);
        }

        [HttpPost]
        [ProducesResponseType(typeof(OrderResponseModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> CheckoutOrder([FromBody] CheckoutOrderCommand checkoutOrder)
        {
            var result = await _mediator.Send(checkoutOrder);
            return ApiCreated(result);
        }
    }
}
