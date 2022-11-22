using EventBus.Messages.Events.Enums;


namespace EventBus.Messages.Events
{
    public class SendSMSEvent : IntegrationBaseEvent
    {
        public string To { get; set; } = "";
        public string Content { get; set; } = "";
    }
}
