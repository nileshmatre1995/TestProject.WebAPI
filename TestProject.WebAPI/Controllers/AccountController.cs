using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TestProject.WebAPI.Business.Interfaces;

namespace TestProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountController(IAccountManager accountManager)
        {
            AccountManager = accountManager;
        }

        public IAccountManager AccountManager { get; }

        [HttpPost]
        [Route("CreateAccount")]
        public IActionResult CreateAccount(Guid userId)
        {
            try
            {
                if (userId == Guid.Empty)
                    return BadRequest("UserId should be valid...");

                var result = AccountManager.CreateAccount(userId);
                if (result != null && result != Guid.Empty)
                    return Ok(result);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ListAccounts")]
        public IActionResult ListAccounts()
        {
            try
            {
                return Ok(AccountManager.ListAccounts());
            }
            catch (Exception ex)
            {
                return Forbid(ex.Message);
            }
        }
    }
}
