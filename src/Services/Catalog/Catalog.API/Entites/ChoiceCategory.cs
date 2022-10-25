using System;
namespace Catalog.API.Entites
{
    public class ChoiceCategory : Base
    {
        public string Name { get; set; } = "";
        public virtual List<Choice> Choices { get; set; } = null!;
    }
}

