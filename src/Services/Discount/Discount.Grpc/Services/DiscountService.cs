using AutoMapper;
using Discount.Grpc.Entites;
using Discount.Grpc.IRepositories;
using Discount.Grpc.Protos;
using Grpc.Core;

namespace Discount.Grpc.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository _discountService;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepository discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }


        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _discountService.GetDiscount(request.ProductName);
            if(coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"coupon with {request.ProductName} not found" ));
            }
            CouponModel model = _mapper.Map<CouponModel>(coupon);

            return model;
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);

            await _discountService.CreateDiscount(coupon);

            return _mapper.Map<CouponModel>(coupon);
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);

            await _discountService.UpdateDiscount(coupon);

            return _mapper.Map<CouponModel>(coupon);
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            await _discountService.DeleteDiscount(request.ProductName);
            return new DeleteDiscountResponse { Success = true };
        }
    }
}
