using AutoMapper;
using EventBus.Messages.Events;
using Notification.API.Models;

namespace Notification.API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SendEmailEvent, EmailMessage>();
        }
    }
}
