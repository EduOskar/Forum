using InaForum.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InaForum.Logic.Commands.CreateCommands
{
    public class CreateUserCommand : IRequest<User>
    {
        public Guid UserId { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string UserName { get; }

        public string Password { get; }

        public string Email { get; }

        public CreateUserCommand(Guid userId, string firstName, string lastName, string userName, string password, string email)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            Email = email;
        }
    }
}
