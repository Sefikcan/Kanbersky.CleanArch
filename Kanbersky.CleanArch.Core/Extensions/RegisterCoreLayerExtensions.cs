using Kanbersky.CleanArch.Core.Caching.Abstract;
using Kanbersky.CleanArch.Core.Caching.Concrete.Redis;
using Kanbersky.CleanArch.Core.Messaging.Abstract;
using Kanbersky.CleanArch.Core.Messaging.Concrete;
using Kanbersky.CleanArch.Core.Messaging.Producer;
using Kanbersky.CleanArch.Core.Settings.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace Kanbersky.CleanArch.Core.Extensions
{
    public static class RegisterCoreLayerExtensions
    {
        public static void RegisterCoreLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ICacheService, RedisCacheService>();
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost";
            });

            RabbitMQSettings rabbitMQSettings = new RabbitMQSettings();
            configuration.GetSection(nameof(RabbitMQSettings)).Bind(rabbitMQSettings);
            services.AddSingleton(rabbitMQSettings);

            services.AddSingleton<IRabbitMQConnection>(sp =>
            {
                var factory = new ConnectionFactory
                {
                    HostName = rabbitMQSettings.HostName,
                    UserName = rabbitMQSettings.UserName,
                    Password = rabbitMQSettings.Password
                };
                return new RabbitMQConnection(factory);
            });

            services.AddSingleton<EventBusRabbitMQProducer>();
        }
    }
}
