using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Entites
{
    public class Base
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    }
}

