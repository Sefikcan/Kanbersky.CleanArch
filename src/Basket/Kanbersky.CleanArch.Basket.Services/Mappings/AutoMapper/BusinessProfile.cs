using AutoMapper;
using Kanbersky.CleanArch.Basket.Services.DTO.Request;
using Kanbersky.CleanArch.Basket.Services.DTO.Response;
using Kanbersky.CleanArch.Core.Messaging.Events;

namespace Kanbersky.CleanArch.Basket.Services.Mappings.AutoMapper
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<AddOrUpdateShoppingCartRequestModel, ShoppingCartResponseModel>().ReverseMap();
            CreateMap<ShoppingCartItemResponseModel, ShoppingCartItemRequestModel>().ReverseMap();

            CreateMap<ShoppingCartCheckoutEvent, CheckoutRequestModel>();
            CreateMap<CheckoutResponseModel, ShoppingCartCheckoutEvent>();
        }
    }
}
