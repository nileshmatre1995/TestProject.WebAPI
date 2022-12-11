using System;
using System.Collections.Generic;
using TestProject.WebAPI.Models;

namespace TestProject.WebAPI.Data.Interfaces
{
    public interface IUserRepository
    {
        public List<User> GetUsers();
        public User GetById(Guid id);
        public Guid SaveUser(User user);
    }
}
