
using AutoMapper;
using Discount.Grpc.Entites;
using Discount.Grpc.Protos;

namespace Discount.Grpc.Mapper
{

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Coupon,CouponModel>().ReverseMap();
        }
    }
}
