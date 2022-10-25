using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Entites
{
    public class ProductChoice: Base
    {
        public Guid? ProductId { get; set; }
        public double PriceIncrease { get; set; } = 0;
        public virtual Product Product { get; set; } = null!;
        public Guid? ChoiceId { get; set; }
        public virtual Choice Choice { get; set; } = null!;
    }
}