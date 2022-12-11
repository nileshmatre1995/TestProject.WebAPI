using System.Collections.Generic;
using System;
using TestProject.WebAPI.Models;

namespace TestProject.WebAPI.Business.Interfaces
{
    public interface IUserManager
    {
        public List<User> GetUsers();
        public User GetUser(Guid id);
        public Guid SaveUser(User user);
    }
}
