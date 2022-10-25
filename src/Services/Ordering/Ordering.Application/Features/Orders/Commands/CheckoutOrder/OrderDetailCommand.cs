
namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder
{
    public class OrderDetailCommand
    {
        public Guid ProductId { get; set; }
        public double Price { get; set; } = 0;
        public int Quantity { get; set; } = 1;
        public string SKU { get; set; } = "";
    }
}

