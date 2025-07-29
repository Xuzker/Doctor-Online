using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorOnline.Domain.ValueObjects
{
    public class Email
    {
        private Email(string value)
        {
            Value = value;
        }

        public string Value { get; } = string.Empty;


        public static Result<Email> Create(string value)
        {
            if (string.IsNullOrEmpty(value))
                return Result.Failure<Email>($"'{nameof(value)}' cannot be null or empty");

            var email = new Email(value);

            return Result.Success(email);
        }

        public override bool Equals(object? obj)
            => obj is Email other && Value == other.Value;

        public override int GetHashCode() => Value.GetHashCode();
    }
}
