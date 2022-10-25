using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Entites
{
    public class Category : Base
    {
        public string Name { get; set; } = "";
        public Guid? ParentId { get; set; }
        public virtual Category? Parent { get; set; }
        public virtual ICollection<Category>? SubCategories { get; set; }
    }
}

