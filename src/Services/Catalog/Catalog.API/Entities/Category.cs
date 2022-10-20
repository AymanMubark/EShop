using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public Guid? ParentId { get; set; }
        public virtual Category? Parent { get; set; }
        public virtual List<Category>? SubCategories { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
