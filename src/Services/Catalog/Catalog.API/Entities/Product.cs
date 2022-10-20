using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string FullDescription { get; set; } = "";
        public string SKU { get; set; } = "";
        public double Price { get; set; }
        public double? OldPrice { get; set; }
        public Category? Category { get; set; }
        public  List<ProductChoice>? ProductChoices { get; set; }
        public  List<ProductInformation>? ProductInformations { get; set; }
        public  List<ProductImage>? ProductImages { get; set; }
    }
}
