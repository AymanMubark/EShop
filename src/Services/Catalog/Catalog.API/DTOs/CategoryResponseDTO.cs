using System;
namespace Catalog.API.DTOs
{
    public class CategoryResponseDTO
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = "";
        public int Count { get; set; }
    }
}

