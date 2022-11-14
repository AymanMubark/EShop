using Notification.API.Models;

namespace Notification.API.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(EmailMessage message);
    }
}
