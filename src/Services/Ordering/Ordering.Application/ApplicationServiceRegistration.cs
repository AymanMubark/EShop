using MediatR;
using FluentValidation;
using System.Reflection;
using Ordering.Application.Mapper;
using Ordering.Application.Behaviours;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;

namespace Ordering.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperProfile).Assembly);
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(CheckoutOrderCommandHandler).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
