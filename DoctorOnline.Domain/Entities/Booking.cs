using CSharpFunctionalExtensions;
using DoctorOnline.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorOnline.Domain.Entities
{
    public class Booking
    {
        private Booking(Guid id, TimeRange timeRange, Guid userId)
        {
            Id = id;
            TimeRange = timeRange;
            UserId = userId;
        }

        public Guid Id { get; }
        public TimeRange TimeRange { get; }
        public Guid UserId { get; }

        public static Result<Booking> Create(TimeRange timeRange, Guid userId)
        {
            if (timeRange == null)
                return Result.Failure<Booking>("Time range cannot be null");

            var booking = new Booking(Guid.NewGuid(), timeRange, userId);
            return Result.Success(booking);
        }

        public bool Overlaps(TimeRange other) => TimeRange.Overlaps(other);
    }
}
