namespace Shopping.Aggregator.Models
{
    public class ChoiceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public virtual ChoiceCategoryModel? ChoiceCategory { get; set; }
    }
}

