﻿using InaForum.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InaForum.Domain.Repository.IRepository
{
    public interface IUserRepository
    {
        public Task<User> GetUser(Guid ids);

        public Task<IEnumerable<User>> GetAllUsers();

        public Task<bool> AddUser(User user);

        public Task<bool> DeleteUser(Guid userId);

        Task<bool> Save();
    }
}
