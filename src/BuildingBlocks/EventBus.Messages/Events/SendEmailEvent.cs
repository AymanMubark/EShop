using EventBus.Messages.Events.Enums;


namespace EventBus.Messages.Events
{
    public class SendEmailEvent : IntegrationBaseEvent
    {
        public string To { get; set; } = "";
        public string ToName { get; set; } = "";
        public string Subject { get; set; } = "";
        public string Content { get; set; } = "";
        public bool IsBodyHtml { get; set; } = false;
    }
}
