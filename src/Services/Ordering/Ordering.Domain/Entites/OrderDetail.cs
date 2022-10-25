using Ordering.Domain.Common;

namespace Ordering.Domain.Entites
{
    public class OrderDetail : EntityBase
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public double Price { get; set; } = 0;
        public int Quantity { get; set; } = 1;
        public string SKU { get; set; } = "";
    }
}

