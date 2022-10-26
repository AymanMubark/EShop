namespace Shopping.Aggregator.Models
{
    public class ProductChoiceModel
    {
        public Guid Id { get; set; }
        public double PriceIncrease { get; set; }
        public ChoiceModel Choice { get; set; }
    }
}