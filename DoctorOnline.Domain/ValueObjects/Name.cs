using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorOnline.Domain.ValueObjects
{
    public class Name
    {
        public const int MIN_NAME_LENGTH = 5;
        private Name(string value)
        {
            Value = value;
        }

        public string Value { get; } = string.Empty;


        public static Result<Name> Create(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length < MIN_NAME_LENGTH)
                return Result.Failure<Name>($"'{nameof(value)}' cannot be empty or less 5 chars");

            var name = new Name(value);

            return Result.Success(name);
        }

        public override bool Equals(object? obj)
            => obj is Name other && Value == other.Value;

        public override int GetHashCode() => Value.GetHashCode();
    }
}
