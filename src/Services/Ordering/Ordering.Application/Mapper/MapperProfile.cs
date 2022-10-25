
using AutoMapper;
using Ordering.Application.DTOs;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using Ordering.Domain.Entites;
using Ordering.Domain.Entites.Enums;

namespace Ordering.Application.Mapper
{

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Order, OrderResponseDTO>().ForMember(dest => dest.Status, opt => opt.MapFrom(x => (OrderStatus)x.Status)).ReverseMap();
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailCommand>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailResponseDTO>().ReverseMap();
        }
    }
}
