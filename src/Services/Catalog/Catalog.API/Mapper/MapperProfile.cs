using AutoMapper;
using Catalog.API.DTOs;
using Catalog.API.Entites;

namespace Catalog.API.Mapper
{

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryResponseDTO>().ForMember(dest=> dest.Count , opt => opt.MapFrom(x => x.SubCategories.Count())).ReverseMap();
            CreateMap<ChoiceCategoryResponseDTO, ChoiceCategory>().ReverseMap();
            CreateMap<ChoiceResponseDTO, Choice>().ReverseMap();
            CreateMap<ProductChoiceReponseDTO, ProductChoice>().ReverseMap();
            CreateMap<ProductImageResponseDTO, ProductImage>().ReverseMap();
            CreateMap<ProductInformationResponseDTO, ProductInformation>().ReverseMap();
            CreateMap<Product, ProductResponseDTO>().ReverseMap();
            CreateMap<Choice, ProductChoiceReponseDTO>().ReverseMap();
        }
    }
}
