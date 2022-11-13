
namespace EventBus.Messages.Events
{
    public class OrderDetail 
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public string ProductImageUrl { get; set; } = "";
        public double Price { get; set; } = 0;
        public int Quantity { get; set; } = 1;
        public string SKU { get; set; } = "";
        public string Choices { get; set; } = "";
    }
}

