using System.Collections.Generic;
using System;
using TestProject.WebAPI.Models;

namespace TestProject.WebAPI.Business.Interfaces
{
    public interface IAccountManager
    {
        Guid CreateAccount(Guid userId);
        List<Account> ListAccounts();
    }
}
