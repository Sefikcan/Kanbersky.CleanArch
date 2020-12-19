using Kanbersky.CleanArch.Catalog.Infrastracture.Entities;
using Kanbersky.CleanArch.Core.Settings.Concrete;
using MongoDB.Driver;

namespace Kanbersky.CleanArch.Catalog.Infrastracture.DbContext.MongoDB
{
    public class CatalogDbContext
    {
        private MongoClient _mongoClient;
        private readonly IMongoDatabase _database;

        public CatalogDbContext(CatalogDbSettings settings)
        {
            _mongoClient = new MongoClient(settings.ConnectionStrings);
            _database = _mongoClient.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<Product> Products { get; set; }
    }
}
