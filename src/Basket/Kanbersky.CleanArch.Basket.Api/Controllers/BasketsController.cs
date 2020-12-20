using Kanbersky.CleanArch.Basket.Services.Abstract;
using Kanbersky.CleanArch.Basket.Services.DTO.Request;
using Kanbersky.CleanArch.Basket.Services.DTO.Response;
using Kanbersky.CleanArch.Core.Results.ApiResponses.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kanbersky.CleanArch.Basket.Api.Controllers
{
    [Route("api/v1/baskets")]
    [ApiController]
    public class BasketsController : CleanArchControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("{userName}")]
        [ProducesResponseType(typeof(ShoppingCartResponseModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBasketByUserName(string userName)
        {
            var response = await _basketService.GetShoppingCart(userName);
            return ApiOk(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCartResponseModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> UpdateBasket([FromBody] AddOrUpdateShoppingCartRequestModel addOrUpdateShoppingCartRequest)
        {
            var response = await _basketService.AddOrUpdateShoppingCart(addOrUpdateShoppingCartRequest);
            return ApiCreated(response);
        }

        [HttpDelete("{userName}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteShoppingCartByUserName(string userName)
        {
            await _basketService.DeleteShoppingCart(userName);
            return ApiNoContent();
        }

        [HttpPost]
        [Route("checkout")]
        [ProducesResponseType(typeof(CheckoutResponseModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> Checkout([FromBody] CheckoutRequestModel checkoutRequest)
        {
            var response = await _basketService.BasketCheckout(checkoutRequest);
            return ApiCreated(response);
        }
    }
}
