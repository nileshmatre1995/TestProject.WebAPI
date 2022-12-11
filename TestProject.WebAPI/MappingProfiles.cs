using AutoMapper;
using TestProject.WebAPI.DTO;
using TestProject.WebAPI.Models;

namespace TestProject.WebAPI
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<AccountDTO, Account>();
            CreateMap<Account, AccountDTO>();
        }
    }
}
