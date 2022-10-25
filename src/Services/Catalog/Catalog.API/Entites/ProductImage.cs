using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.API.Entites
{
    public class ProductImage: Base
    {
        public string? ImageUrl { get; set; }
        public string? ImageId { get; set; }
        public Guid? ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}

