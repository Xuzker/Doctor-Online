using DoctorOnline.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorOnline.Domain.Repositories
{
    public interface IMeetingRoomRepository
    {
        Task<MeetingRoom?> GetByIdAsync(Guid id);
        Task<List<MeetingRoom>> GetAvailableRoomsAsync(DateTime date);
        Task AddAsync(MeetingRoom room);
    }
}
