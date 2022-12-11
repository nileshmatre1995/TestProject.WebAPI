using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using System;
using System.Collections.Generic;
using System.Linq;
using TestProject.WebAPI.Data.Interfaces;
using TestProject.WebAPI.Models;

namespace TestProject.WebAPI.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(Context context)
        {
            Context = context;
        }

        public Context Context { get; }

        public User GetById(Guid id) => Context.Users.Find(id);

        public List<User> GetUsers() => Context.Users.ToList();

        public Guid SaveUser(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
            return user.Id;
        }
    }
}
