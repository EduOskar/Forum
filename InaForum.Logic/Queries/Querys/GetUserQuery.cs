using InaForum.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InaForum.Logic.Queries.Querys
{
    public class GetUserQuery : IRequest<User>
    {
        public Guid UserId { get; }

        public GetUserQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
