using CSharpFunctionalExtensions;
using DoctorOnline.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorOnline.Domain.Entities
{
    public class User
    {
        private User(Guid id, Name name, Email email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public Guid Id { get; }
        public Name Name { get; }
        public Email Email { get; }
        public static Result<User> Create(Name name, Email email)
        {
            if (name == null || email == null)
                return Result.Failure<User>($"Name or Email cannot null");
            var user = new User(Guid.NewGuid(), name, email);
            return Result.Success(user);
        }
    }
}
