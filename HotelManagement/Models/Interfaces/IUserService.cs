using HotelManagement.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HotelManagement.Models.Interfaces
{
    public interface IUserService
    {
      
        Task<UserDTO> Register(RegisterUserDTO data, ModelStateDictionary modelState);
        Task<UserDTO> Authenticate(string username, string password);
        Task<UserDTO> GetUser(ClaimsPrincipal principal);
    }
}
