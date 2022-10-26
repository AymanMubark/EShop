namespace Shopping.Aggregator.Models
{
    public class OrderDetailModel
    {
        public Guid ProductId { get; set; }
        public double Price { get; set; } = 0;
        public int Quantity { get; set; } = 1;
        public string SKU { get; set; } = "";
    }
}
