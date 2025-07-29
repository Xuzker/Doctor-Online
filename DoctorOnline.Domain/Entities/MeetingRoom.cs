using CSharpFunctionalExtensions;
using DoctorOnline.Domain.DomainEvents;
using DoctorOnline.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorOnline.Domain.Entities
{
    public class MeetingRoom
    {
        private MeetingRoom(Guid id, Name name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public Name Name { get; }

        private readonly List<Booking> _bookings = new();
        public IReadOnlyCollection<Booking> Bookings => _bookings.AsReadOnly();

        private readonly List<DomainEvent> _domainEvents = new();
        public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public static Result<MeetingRoom> Create(Name name)
        {
            if (name == null)
                return Result.Failure<MeetingRoom>("Name cannot be empty");

            var meetingRoom = new MeetingRoom(Guid.NewGuid(), name);
            return Result.Success(meetingRoom);
        }

        public Result<Booking> Book(TimeRange timeRange, Guid userId)
        {
            if (_bookings.Any(b => b.Overlaps(timeRange)))
                return Result.Failure<Booking>("Time overlaps with existing booking");

            var bookingResult = Booking.Create(timeRange, userId);
            if (bookingResult.IsFailure)
                return Result.Failure<Booking>(bookingResult.Error);

            _bookings.Add(bookingResult.Value);

            var roomBookedEvent = RoomBookedEvent.Create(this.Id, userId, timeRange);
            _domainEvents.Add(roomBookedEvent);

            return Result.Success(bookingResult.Value);
        }
    }
}
