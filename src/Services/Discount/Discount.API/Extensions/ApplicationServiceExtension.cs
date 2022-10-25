using Discount.API.IServices;
using Discount.API.Services;

namespace Discount.API.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IDiscountService, DiscountService>();
            return services;
        }
    }
}
