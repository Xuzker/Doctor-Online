using DoctorOnline.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorOnline.Domain.Services
{
    public interface INotificationService
    {
        Task SendBookingConfirmationEmail(string email, string name, DateTime start, DateTime end);
        Task NotifyUserAsync(Guid id, string message);
    }
}
