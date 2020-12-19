using AutoMapper;
using Kanbersky.CleanArch.Catalog.Services.Abstract;
using Kanbersky.CleanArch.Catalog.Services.Concrete;
using Kanbersky.CleanArch.Catalog.Services.Mappings.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Kanbersky.CleanArch.Catalog.Services.Extensions
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

            services.AddScoped<IProductService, ProductService>();
        }
    }
}
