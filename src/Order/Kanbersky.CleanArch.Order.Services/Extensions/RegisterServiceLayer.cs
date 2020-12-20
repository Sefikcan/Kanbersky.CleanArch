using AutoMapper;
using Kanbersky.CleanArch.Order.Services.Mappings.AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Kanbersky.CleanArch.Order.Services.Extensions
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

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
