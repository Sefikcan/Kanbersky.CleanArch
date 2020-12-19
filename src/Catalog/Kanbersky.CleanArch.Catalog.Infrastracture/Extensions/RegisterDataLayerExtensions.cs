using Kanbersky.CleanArch.Core.Repositories.Abstract.MongoDB;
using Kanbersky.CleanArch.Core.Repositories.Concrete.MongoDB;
using Kanbersky.CleanArch.Core.Settings.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kanbersky.CleanArch.Catalog.Infrastracture.Extensions
{
    public static class RegisterDataLayerExtensions
    {
        public static void RegisterDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            CatalogDbSettings catalogDbSettings = new CatalogDbSettings();
            configuration.GetSection(nameof(CatalogDbSettings)).Bind(catalogDbSettings);
            services.AddSingleton(catalogDbSettings);
            services.AddScoped(typeof(IMongoGenericRepository<>), typeof(MongoGenericRepository<>));
        }
    }
}
