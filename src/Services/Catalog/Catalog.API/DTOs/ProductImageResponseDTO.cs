using System;
namespace Catalog.API.DTOs
{
    public class ProductImageResponseDTO
    {
        public Guid Id { get; set; }
        public string? ImageUrl { get; set; }
    }
}

