using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using Notification.API.Models;
using Notification.API.Services;

namespace Notification.API.EventBusConsumer
{
    public class SendEmailConsumer : IConsumer<SendEmailEvent>
    {
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public SendEmailConsumer(IEmailService emailService, IMapper mapper)
        {
            _emailService = emailService;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<SendEmailEvent> context)
        {
            var message = _mapper.Map<EmailMessage>(context.Message);
            Console.WriteLine(message.Content);
            await _emailService.SendEmailAsync(message);
        }
    }
}
