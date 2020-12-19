using Kanbersky.CleanArch.Basket.Services.DTO.Request;
using Kanbersky.CleanArch.Basket.Services.DTO.Response;
using System.Threading.Tasks;

namespace Kanbersky.CleanArch.Basket.Services.Abstract
{
    public interface IBasketService
    {
        Task<ShoppingCartResponseModel> GetShoppingCart(string userName);

        Task DeleteShoppingCart(string userName);

        Task<ShoppingCartResponseModel> AddOrUpdateShoppingCart(AddOrUpdateShoppingCartRequestModel addOrUpdateShoppingCartRequest);

        Task<CheckoutResponseModel> BasketCheckout(CheckoutRequestModel checkoutRequest);
    }
}
