using InaForum.Domain.Models;
using InaForum.Domain.Repository.IRepository;
using InaForum.Logic.Queries.Querys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InaForum.Logic.Queries.QueryHandlers
{
    public class GetAllUsersQueryHandler(IUserRepository userRepository) : IRequestHandler<GetAllUsersQuery, ICollection<User>>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<ICollection<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUsers();

            return (ICollection<User>)await Task.FromResult(users);
        }
    }
}
