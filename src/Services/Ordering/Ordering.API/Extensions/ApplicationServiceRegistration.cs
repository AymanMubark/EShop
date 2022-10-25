using EventBus.Messages.Common;
using FluentValidation;
using MassTransit;
using MediatR;
using Ordering.API.EventBusConsumer;
using Ordering.API.Mapper;
using Ordering.Application.Behaviours;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using Ordering.Application.Mapper;
using System.Reflection;

namespace Ordering.API.Extensions
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MapperProfile).Assembly);
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(CheckoutOrderCommand).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));


            services.AddAutoMapper(typeof(OrderingMapper).Assembly);

            //RabbitMq
            services.AddMassTransit(config => {
                config.AddConsumer<BasketCheckoutConsumer>();
                config.UsingRabbitMq((ctx, cfg) => {
                    cfg.Host(configuration["EventBusSettings:HostAddress"]);
                    cfg.ReceiveEndpoint(EventBusConstants.BasketCheckoutQueue, c =>
                    {
                        c.ConfigureConsumer<BasketCheckoutConsumer>(ctx);

                    });
                });
            });

            return services;
        }
    }
}
