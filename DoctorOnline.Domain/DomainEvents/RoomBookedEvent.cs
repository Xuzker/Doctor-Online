using DoctorOnline.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorOnline.Domain.DomainEvents
{
    public class RoomBookedEvent: DomainEvent
    {
        private RoomBookedEvent(Guid roomId, Guid userId, TimeRange timeRange)
        {
            RoomId = roomId;
            UserId = userId;
            TimeRange = timeRange;
        }

        public Guid RoomId { get; }
        public Guid UserId { get; }
        public TimeRange TimeRange { get; }

        public static RoomBookedEvent Create(Guid roomId, Guid userId, TimeRange timeRange)
        {
            return new RoomBookedEvent(roomId, userId, timeRange);
        }
    }
}
