using HotelManagement.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace HotelManagement.Models.Interfaces
{
    public interface IUserService
    {
        public Task Register(RegisterUserDTO data, ModelStateDictionary modelState);
        public Task<UserDTO> Authenticate(string username, string password);
    }
}
