using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorOnline.Domain.Interfaces
{
    public interface INotificationService
    {
        Task NotifyUserAsync(Guid userId, string message);
    }
}
