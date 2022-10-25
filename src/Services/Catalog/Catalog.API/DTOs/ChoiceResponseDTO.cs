using System;
using Catalog.API.Entites;

namespace Catalog.API.DTOs
{
    public class ChoiceResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public virtual ChoiceCategoryResponseDTO? ChoiceCategory { get; set; }
    }
}

