using InaForum.Domain.Models;
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
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {

            if (await _userRepository.DeleteUser(request.UserId))
            {
                return true;
            }

            return false;
        }
    }
}

