namespace Discount.API.Entites
{
    public class Coupon
    { 
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }
}
