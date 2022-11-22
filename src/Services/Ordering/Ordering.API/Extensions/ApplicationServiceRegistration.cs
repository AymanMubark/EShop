using MediatR;
using MassTransit;
using FluentValidation;
using EventBus.Messages.Common;
using EventBus.Messages.Events;
using Ordering.Application.Mapper;
using Ordering.Application.Behaviours;
using Ordering.API.EventBusConsumer;
using Ordering.API.Mapper;
using System.Reflection;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;

namespace Ordering.API.Extensions
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks();
            services.AddAutoMapper(typeof(MapperProfile).Assembly);
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(CheckoutOrderCommand).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));


            services.AddAutoMapper(typeof(OrderingMapper).Assembly);

           services.AddMassTransit(x =>
            {
                x.AddConsumer<BasketCheckoutConsumer>();
                x.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.ReceiveEndpoint(EventBusConstants.BasketCheckoutQueue, c =>
                    {
                        c.ConfigureConsumer<BasketCheckoutConsumer>(ctx);
                    });
                    cfg.ConfigureEndpoints(ctx);
                });

                x.AddRider(rider =>
                {
                    rider.AddProducer<SendEmailEvent>(nameof(SendEmailEvent));
                    rider.AddProducer<SendSMSEvent>(nameof(SendSMSEvent));

                    rider.UsingKafka((ctx, k) =>
                    {
                        k.Host("localhost:9092");
                    });
                });
            });


            return services;
        }
       
    }
}
