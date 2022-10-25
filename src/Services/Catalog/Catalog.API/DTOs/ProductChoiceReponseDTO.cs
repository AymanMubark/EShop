using Catalog.API.Entites;

namespace Catalog.API.DTOs
{
    public class ProductChoiceReponseDTO
    {
        public Guid Id { get; set; }
        public double PriceIncrease { get; set; }
        public ChoiceResponseDTO Choice { get; set; }
    }
}