namespace Notification.API.Models
{
    public class EmailMessage
    {
        public string To { get; set; } = "";
        public string ToName { get; set; } = "";
        public string Subject { get; set; } = "";
        public string Content { get; set; } = "";
        public bool IsBodyHtml { get; set; } = false;
    }
}
