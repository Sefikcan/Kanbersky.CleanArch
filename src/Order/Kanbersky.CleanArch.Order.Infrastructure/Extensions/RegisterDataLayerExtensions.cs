using Kanbersky.CleanArch.Core.Repositories.Abstract.EntityFramework;
using Kanbersky.CleanArch.Core.Settings.Concrete;
using Kanbersky.CleanArch.Order.Infrastructure.Context.EntityFramework;
using Kanbersky.CleanArch.Order.Infrastructure.GenericRepository.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kanbersky.CleanArch.Order.Infrastructure.Extensions
{
    public static class RegisterDataLayerExtensions
    {
        public static void RegisterDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            OrderDbSettings orderDbSettings = new OrderDbSettings();
            configuration.GetSection(nameof(OrderDbSettings)).Bind(orderDbSettings);
            services.AddSingleton(orderDbSettings);

            services.AddDbContext<OrderDbContext>(c =>
                c.UseSqlServer(orderDbSettings.ConnectionStrings),ServiceLifetime.Singleton);

            services.AddScoped(typeof(IEfGenericRepository<>), typeof(EfGenericRepository<>));
        }
    }
}
