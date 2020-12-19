using Kanbersky.CleanArch.Core.Entity;
using MongoDB.Bson.Serialization.Attributes;

namespace Kanbersky.CleanArch.Catalog.Infrastracture.Entities
{
    public class Product : BaseMongoEntity, IEntity
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        public string Category { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public string ImageFile { get; set; }

        public decimal Price { get; set; }
    }
}
