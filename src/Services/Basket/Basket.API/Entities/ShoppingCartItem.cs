namespace Basket.API.Entities
{
    public class ShoppingCartItem
    {
        public string ProductId { get; set; } = "";
        public string ProductName { get; set; } = "";
        public string ProductImageUrl { get; set; } = "";
        public int Quantity { get; set; } = 1;
        public decimal Price { get; set; } = 0;
    }
}
