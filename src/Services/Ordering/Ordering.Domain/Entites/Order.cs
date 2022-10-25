using Ordering.Domain.Entites.Enums;
using Ordering.Domain.Common;

namespace Ordering.Domain.Entites
{
    public class Order : EntityBase
    {
        public string UserName { get; set; }
        public string OrderId { get; set; } = "";
        public  OrderStatus Status { get; set; } = OrderStatus.New;
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
        public ICollection<OrderDetail> OrderDetails { get; set; } = null!;
    }
}

