using System;
using Catalog.API.Entites;

namespace Catalog.API.DTOs
{
    public class ProductResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string FullDescription { get; set; } = "";
        public string SKU { get; set; } = "";
        public double Price { get; set; }
        public double? OldPrice { get; set; }
        public virtual CategoryResponseDTO? Category { get; set; }
        public virtual List<ProductImageResponseDTO> ProductImages { get; set; }
        public virtual List<ProductChoiceReponseDTO>? ProductChoices { get; set; }
        public virtual List<ProductInformationResponseDTO> ProductInformations { get; set; }
        
    }
}


