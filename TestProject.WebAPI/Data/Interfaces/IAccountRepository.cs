using System;
using System.Collections.Generic;
using TestProject.WebAPI.Models;

namespace TestProject.WebAPI.Data.Interfaces
{
    public interface IAccountRepository
    {
        Guid CreateAccount(Account account);
        List<Account> ListAccounts();
    }
}
