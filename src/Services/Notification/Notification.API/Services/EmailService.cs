using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;
using Notification.API.Models;

namespace Notification.API.Services
{
    public class EmailService : IEmailService
    {
        private IConfiguration _configuration;
        private readonly SmtpClient _smtpClient;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            _smtpClient = new SmtpClient(_configuration["EmailSettings:SmtpClient"], 2525)
            {
                Credentials = new NetworkCredential(_configuration["EmailSettings:UserName"], _configuration["EmailSettings:Password"]),
                EnableSsl = true
            };
        }

        public async Task<bool> SendEmailAsync(EmailMessage model)
        {
            MailMessage message = new MailMessage {
                From = new MailAddress(_configuration["EmailSettings:FromEmail"]),
                Subject = model.Subject, 
                Body= model.Content,
                IsBodyHtml= model.IsBodyHtml
            };
            message.To.Add(new MailAddress(model.To, model.ToName));
            await _smtpClient.SendMailAsync(message);
            return true;
        }
    }
}