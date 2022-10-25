using System;
namespace Catalog.API.DTOs
{
    public class ProductSearchDTO : PaginationParamsDTO
    {
        public string? SearchKey { get; set; } = "";
        public Guid? CategoryId { get; set; }
        public string? SortBy { get; set; } = "";
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public string? ChoicesId { get; set; }
    }
}

