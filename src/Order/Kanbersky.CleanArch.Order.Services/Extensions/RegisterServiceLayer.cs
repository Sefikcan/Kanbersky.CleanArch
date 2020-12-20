using AutoMapper;
using Kanbersky.CleanArch.Order.Services.Consumers;
using Kanbersky.CleanArch.Order.Services.Mappings.AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

            services.AddSingleton<EventBusRabbitMQConsumer>();

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static EventBusRabbitMQConsumer Listener { get; set; }

        public static IApplicationBuilder UseServiceLayer(this IApplicationBuilder app)
        {
            Listener = app.ApplicationServices.GetService<EventBusRabbitMQConsumer>();
            var life = app.ApplicationServices.GetService<IHostApplicationLifetime>();

            life.ApplicationStarted.Register(OnStarted);
            life.ApplicationStopping.Register(OnStopping);

            return app;
        }

        private static void OnStarted()
        {
            Listener.Consume();
        }

        private static void OnStopping()
        {
            Listener.Disconnect();
        }
    }
}
