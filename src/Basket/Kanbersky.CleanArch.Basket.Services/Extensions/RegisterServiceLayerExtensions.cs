using AutoMapper;
using Kanbersky.CleanArch.Basket.Services.Abstract;
using Kanbersky.CleanArch.Basket.Services.Concrete;
using Kanbersky.CleanArch.Basket.Services.Mappings.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Kanbersky.CleanArch.Basket.Services.Extensions
{
    public static class RegisterServiceLayerExtensions
    {
        public static void RegisterServiceLayer(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BusinessProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IBasketService, BasketService>();
        }
    }
}
