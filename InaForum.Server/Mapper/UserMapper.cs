using InaForum.Domain.Models;
using InaForum.Server.ViewModels;
using System.Runtime.CompilerServices;

namespace InaForum.Server.Mapper
{
    public static class UserMapper
    {
        public static UserViewModel Map(this User user) => new()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Username = user.UserName,
            Email = user.Email,
        };
    }
}
