using Castle.Core.Logging;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using TestProject.WebAPI.Business.Interfaces;
using TestProject.WebAPI.Data.Interfaces;
using TestProject.WebAPI.Models;

namespace TestProject.WebAPI.Business
{
    public class UserManager : IUserManager
    {
        public UserManager(IUserRepository userRepository, ILogger<UserManager> logger)
        {
            UserRepository = userRepository;
            Logger = logger;
        }

        public IUserRepository UserRepository { get; }
        public ILogger<UserManager> Logger { get; }

        public User GetUser(Guid id)
        {
            try
            {
                return UserRepository.GetById(id);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            try
            {
                users = UserRepository.GetUsers();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
            }
            return users;
        }

        public Guid SaveUser(User user)
        {
            Guid result = Guid.Empty;
            try
            {
                if(user != null)
                {
                    if (user.MonthlySalary < 0) throw new Exception("Monthly Salary should not be negative.");
                    if (user.MonthlyExpenses < 0) throw new Exception("Monthly Exprenses should not be negative.");

                    result = UserRepository.SaveUser(user);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
            return result;
        }
    }
}
