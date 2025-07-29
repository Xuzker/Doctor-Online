using DoctorOnline.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorOnline.Domain.Interfaces
{
    public interface IMeetingRoomRepository
    {
        Task<MeetingRoom?> GetByIdAsync(Guid id);
        Task AddAsync(MeetingRoom room);
        Task SaveChangesAsync();
    }
}
