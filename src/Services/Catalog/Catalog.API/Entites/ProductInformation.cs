using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Entites
{
    public class ProductInformation: Base
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public Guid? ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}

