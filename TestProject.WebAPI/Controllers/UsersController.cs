using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using TestProject.WebAPI.Business.Interfaces;
using TestProject.WebAPI.Data.Interfaces;
using TestProject.WebAPI.DTO;
using TestProject.WebAPI.Models;

namespace TestProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController(IUserManager userManager, IMapper mapper)
        {
            UserManager = userManager;
            Mapper = mapper;
        }

        public IUserManager UserManager { get; }
        public IMapper Mapper { get; }

        [HttpGet]
        [Route("ListUsers")]
        public IActionResult ListUsers()
        {
            var result = UserManager.GetUsers();
            if(result != null && result.Count > 0)
                return Ok(result);
            return NoContent();
        }
        [HttpGet]
        [Route("GetUser")]
        public IActionResult GetUser(Guid id)
        {
            try
            {
                var user = UserManager.GetUser(id);
                if (user != null)
                    return Ok(user);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        [Route("SaveUser")]
        public IActionResult SaveUser(UserDTO userDTO)
        {
            try
            {
                var id = UserManager.SaveUser(Mapper.Map<User>(userDTO));
                if (id != null && id != Guid.Empty)
                    return Ok(id);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ??  ex.Message);
            }
           
        }
    }
}
