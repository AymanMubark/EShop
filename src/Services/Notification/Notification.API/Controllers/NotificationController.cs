using Microsoft.AspNetCore.Mvc;
using Notification.API.Models;
using Notification.API.Services;

namespace Notification.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class NotificationController : ControllerBase
    {


        private readonly IEmailService _emailService;
        private readonly ILogger<NotificationController> _logger;

        public NotificationController(ILogger<NotificationController> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmailMessage model)
        {
            await _emailService.SendEmailAsync(model);
            return Ok();
        }
    }
}