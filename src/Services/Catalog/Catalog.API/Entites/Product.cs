using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Entites
{
    public class Product: Base
    {
            public string Name { get; set; } = "";
            public string Description { get; set; } = "";
            public string FullDescription { get; set; } = "";
            public string SKU { get; set; } = "";
            public double Price { get; set; } 
            public double? OldPrice { get; set; }
            public Guid? CategoryId { get; set; }
            public virtual Category? Category { get; set; } 
            public virtual ICollection<ProductChoice>? ProductChoices { get; set; }
            public virtual ICollection<ProductInformation>? ProductInformations { get; set; }
            public virtual ICollection<ProductImage>? ProductImages { get; set; }
    }
}

