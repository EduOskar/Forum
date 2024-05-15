using InaForum.Domain.Models;
using InaForum.Domain.Repository.IRepository;
using InaForum.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InaForum.Domain.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddUser(User user)
        {
            await _dbContext.AddAsync(user);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<User> GetUser(Guid ids)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == ids);

            if (user != null)
            {
                return user;
            }

            throw new Exception("No user with that Guid exist");
        }
    }
}
