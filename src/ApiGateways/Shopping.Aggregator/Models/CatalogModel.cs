namespace Shopping.Aggregator.Models
{
    public class CatalogModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string FullDescription { get; set; } = "";
        public string SKU { get; set; } = "";
        public decimal Price { get; set; }
        public double? OldPrice { get; set; }
        public virtual CategoryModel? Category { get; set; }
        public virtual List<ProductImageModel> ProductImages { get; set; }
        public virtual List<ProductChoiceModel>? ProductChoices { get; set; }
        public virtual List<ProductInformationModel> ProductInformations { get; set; }
    }
}
