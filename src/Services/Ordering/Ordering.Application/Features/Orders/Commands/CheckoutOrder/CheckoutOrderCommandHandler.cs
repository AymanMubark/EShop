﻿using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Entites;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publisher;

        public CheckoutOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IPublishEndpoint publisher)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _publisher = publisher;
        }

        public async Task<Guid> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<Order>(request);
            var orderId = await _orderRepository.GetOrdersCount();
            orderEntity.OrderId = $"#{++orderId}";
            orderEntity.Status = Domain.Entites.Enums.OrderStatus.New;
            var newOrder = await _orderRepository.AddAsync(orderEntity);

            SendEmailEvent message = new SendEmailEvent
            {
                To = newOrder.Email,
                IsBodyHtml= true,
                Subject = "EShop Order",
                Content = $"<h1 style='color:#fb5c42;text-align: center;'>EShop</h1><p>Order Number {newOrder.OrderId} Recived</p>",
            };

            message.Content += "<table><tbody>";
            foreach (var item in newOrder.OrderDetails)
            {
                message.Content += $"<tr><td><img style='max-width:100px;max-height:100px;' src='{item.ProductImageUrl}' /></td><td>{item.ProductName}</td><td>{item.Price} x {item.Quantity}</td></tr>";
            }

            message.Content += $"</tbody></table><h5>Tax : {newOrder.Tax}$</h5><h4>Total : {newOrder.TotalPrice}$</h4>";
            await _publisher.Publish(message);
            return newOrder.Id;
        }

 
    
    }
}
