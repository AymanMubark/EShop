using Discount.Grpc.IRepositories;
using Discount.Grpc.Mapper;
using Discount.Grpc.Repositories;

namespace Discount.Grpc.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddAutoMapper(typeof(MapperProfile).Assembly);
            return services;
        }
    }
}
