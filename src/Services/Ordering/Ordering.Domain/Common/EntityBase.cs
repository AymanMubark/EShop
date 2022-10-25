using System.ComponentModel.DataAnnotations;

namespace Ordering.Domain.Common
{
    public class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
