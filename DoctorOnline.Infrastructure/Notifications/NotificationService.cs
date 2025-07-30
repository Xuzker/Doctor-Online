using DoctorOnline.Domain.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;

namespace DoctorOnline.Infrastructure.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly ILogger<NotificationService> _logger;
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(ILogger<NotificationService> logger, IHubContext<NotificationHub> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        public async Task NotifyUserAsync(Guid userId, string message)
        {
            try
            {
                await _hubContext.Clients.User(userId.ToString())
                    .SendAsync("ReceiveNotification", message);

                _logger.LogInformation("Sent real-time notification to user {UserId}", userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send real-time notification to user {UserId}", userId);
            }
        }

        public async Task SendBookingConfirmationEmail(string email, string name, DateTime start, DateTime end)
        {
            try
            {
                var from = new MailAddress("noreply@doctoronline.com", "DoctorOnline");
                var to = new MailAddress(email, name);
                var subject = "Booking Confirmation";
                var body = $"""
                    Dear {name},

                    Your booking has been confirmed from {start:G} to {end:G}.

                    Thank you,
                    DoctorOnline
                    """;

                using var smtp = new SmtpClient("smtp.yourserver.com", 587)
                {
                    Credentials = new NetworkCredential("your_username", "your_password"),
                    EnableSsl = true
                };

                var mail = new MailMessage(from, to)
                {
                    Subject = subject,
                    Body = body
                };

                await smtp.SendMailAsync(mail);
                _logger.LogInformation("Sent booking confirmation email to {Email}", email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send booking confirmation email to {Email}", email);
            }
        }
    }
}
