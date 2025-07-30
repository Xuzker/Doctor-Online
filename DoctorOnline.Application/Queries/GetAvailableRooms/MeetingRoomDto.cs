using DoctorOnline.Domain.ValueObjects;

namespace DoctorOnline.Application.Queries.GetAvailableRooms
{
    public class MeetingRoomDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Capacity { get; set; }
    }
}