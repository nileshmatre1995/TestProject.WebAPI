using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TestProject.WebAPI.Data.Interfaces;
using TestProject.WebAPI.Models;

namespace TestProject.WebAPI.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public AccountRepository(Context context)
        {
            Context = context;
        }

        public Context Context { get; }

        public Guid CreateAccount(Account account)
        {
            Context.Accounts.Add(account);
            Context.SaveChanges();
            return account.Id;
        }

        public List<Account> ListAccounts() => Context.Accounts.Include(x => x.Users).ToList();
    }
}
