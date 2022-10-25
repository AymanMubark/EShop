
namespace Ordering.Application.DTOs
{
    public class OrderDetailResponseDTO
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public double Price { get; set; } = 0;
        public int Quantity { get; set; } = 1;
        public string SKU { get; set; } = "";
    }
}

