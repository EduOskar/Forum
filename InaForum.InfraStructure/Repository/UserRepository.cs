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

            return await Save();
        }

        public async Task<bool> DeleteUser(Guid userId)
        {
            var userToDelete = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (userToDelete != null)
            {
                _dbContext.Remove(userToDelete);

                return await Save();
            }

            throw new Exception("Could not delete users");
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _dbContext.Users.ToListAsync();

            if (users is not null)
            {
                return users;
            }

            throw new Exception("Could not get list of users");
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

        public async Task<bool> Save()
        {
           var save = await _dbContext.SaveChangesAsync();

            return save > 0;
        }
    }
}
