using AutoMapper;
using Kanbersky.CleanArch.Catalog.Infrastracture.Entities;
using Kanbersky.CleanArch.Catalog.Services.DTO.Request;
using Kanbersky.CleanArch.Catalog.Services.DTO.Response;

namespace Kanbersky.CleanArch.Catalog.Services.Mappings.AutoMapper
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<Product, CreateProductRequestModel>().ReverseMap();
            CreateMap<Product, ProductResponseModel>().ReverseMap();

            CreateMap<Product, UpdateProductRequestModel>().ReverseMap();
        }
    }
}
