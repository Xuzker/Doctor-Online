using DoctorOnline.Domain.Entities;
using DoctorOnline.Domain.Repositories;
using DoctorOnline.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace DoctorOnline.Infrastructure.Persistence
{
    public class MeetingRoomRepository : IMeetingRoomRepository
    {
        private readonly AppDbContext _context;

        public MeetingRoomRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<MeetingRoom?> GetByIdAsync(Guid id)
        {
            return await _context.MeetingRooms.FindAsync(id);
        }

        public async Task<List<MeetingRoom>> GetAvailableRoomsAsync(DateTime date)
        {
            var startOfDay = date.Date;
            var endOfDay = date.Date.AddDays(1);

            return await _context.MeetingRooms
                .Where(r => !r.Bookings.Any(b =>
                    b.TimeRange.Start < endOfDay && b.TimeRange.End > startOfDay))
                .ToListAsync();
        }

        public async Task AddAsync(MeetingRoom room)
        {
            await _context.MeetingRooms.AddAsync(room);
        }
    }
}
