using CSharpFunctionalExtensions;
using DoctorOnline.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorOnline.Domain.ValueObjects
{
    public class TimeRange
    {
        private TimeRange(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTime Start { get; }
        public DateTime End { get; }

        public static Result<TimeRange> Create(DateTime start, DateTime end)
        {
            if (start >= end)
                return Result.Failure<TimeRange>($"The start({nameof(start)}) is greater than the end({nameof(end)})");
            var timeRange = new TimeRange(start, end);
            return Result.Success(timeRange);
        }

        public bool Overlaps(TimeRange other) 
            => Start < other.End && other.Start < End;
    }
}
