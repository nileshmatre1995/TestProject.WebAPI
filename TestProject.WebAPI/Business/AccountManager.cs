using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using TestProject.WebAPI.Business.Interfaces;
using TestProject.WebAPI.Data.Interfaces;
using TestProject.WebAPI.DTO;
using TestProject.WebAPI.Models;

namespace TestProject.WebAPI.Business
{
    public class AccountManager : IAccountManager
    {
        public AccountManager(IAccountRepository accountRepository, IUserManager userManager, ILogger<AccountManager> logger, IMapper mapper)
        {
            AccountRepository = accountRepository;
            UserManager = userManager;
            Logger = logger;
            Mapper = mapper;
        }

        public IAccountRepository AccountRepository { get; }
        public IUserManager UserManager { get; }
        public ILogger<AccountManager> Logger { get; }
        public IMapper Mapper { get; }

        public Guid CreateAccount(Guid userId)
        {
            Guid result = Guid.Empty;
            try
            {
                if(userId != Guid.Empty)
                {
                    var user = UserManager.GetUser(userId);
                    if (user != null)
                    {
                        if (user.MonthlySalary - user.MonthlyExpenses < 1000)
                            throw new Exception("Can't create an account. monthly salary - monthly expenses is less than $1000");

                        AccountDTO accountDTO = new AccountDTO()
                        {
                            CreatedDate = DateTime.UtcNow,
                            UserId = userId
                        };

                        result = AccountRepository.CreateAccount(Mapper.Map<Account>(accountDTO));
                    }
                    else
                        throw new Exception("No user found...");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
            return result;
        }

        public List<Account> ListAccounts()
        {
            List<Account> result = new List<Account>();
            try
            {
                result = AccountRepository.ListAccounts();
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
