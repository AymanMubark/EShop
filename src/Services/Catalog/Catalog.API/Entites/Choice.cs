using System;
namespace Catalog.API.Entites
{
    public class Choice: Base
    {
        public string Name { get; set; } = "";
        public Guid? ChoiceCategoryId { get; set; }
        public virtual ChoiceCategory? ChoiceCategory { get; set; }
    }
}

