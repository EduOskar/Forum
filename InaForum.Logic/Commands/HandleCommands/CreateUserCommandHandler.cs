using InaForum.Domain.Models;
using InaForum.Domain.Repository;
using InaForum.Domain.Repository.IRepository;
using InaForum.Logic.Commands.CreateCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InaForum.Logic.Commands.HandleCommands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.FirstName, request.LastName, request.UserName, request.Password, request.Email);

            if (await _userRepository.AddUser(user))
            {
                return user;
            }

            throw new Exception("Could not create User");

        } 
    }
}
