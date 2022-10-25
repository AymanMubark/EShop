
namespace Ordering.Application.DTOs
{
    public class OrderResponseDTO
    {
        public string UserName { get; set; }
        public Guid Id { get; set; }
        public string OrderId { get; set; } = "";
        public DateTime CreatedDate { get; set; } 
        public string Status { get; set; } 
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public double Tax { get; set; } = 0;
        public string Region { get; set; } = "";
        public string City { get; set; } = "";
        public string Details { get; set; } = "";
        public string ZipCode { get; set; } = "";
        public string Note { get; set; } = "";
        public decimal TotalPrice { get; set; }
        public ICollection<OrderDetailResponseDTO> OrderDetails { get; set; } = null!;
    }
}

