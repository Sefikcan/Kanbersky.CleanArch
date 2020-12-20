using AutoMapper;
using Kanbersky.CleanArch.Order.Services.Commands;
using Kanbersky.CleanArch.Order.Services.DTO.Response;

namespace Kanbersky.CleanArch.Order.Services.Mappings.AutoMapper
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<Infrastructure.Entities.Order, OrderResponseModel>().ReverseMap();
            CreateMap<Infrastructure.Entities.Order, CheckoutOrderCommand>().ReverseMap();
        }
    }
}
