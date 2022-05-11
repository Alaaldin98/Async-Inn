using HotelManagement.Models.DTO;
using HotelManagement.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;


namespace HotelManagement.Models.Servieces
{
    public class IdentityUserService : IUserService
    {
        private UserManager<ApplicationUser> userManager;

        public IdentityUserService(UserManager<ApplicationUser> manager)
        {
            userManager = manager;
        }
        public async Task<UserDTO> Authenticate(string username, string password)
        {

            var user = await userManager.FindByNameAsync(username);
            if (user != null)
            {
                if (await userManager.CheckPasswordAsync(user, password))
                {
                    UserDTO userDto = new UserDTO
                    {
                        Id = user.Id,
                        Username = user.UserName,
                    };
                    return userDto;
                }
            }
            return null;
        }

        public async Task<UserDTO> Register(RegisterUserDTO data, ModelStateDictionary modelState)
        {
            var userDTO = new ApplicationUser
            {
                UserName = data.Username,
                Email = data.Email,
                Gender = data.Gender,
                PasswordHash = data.Password


            };
            
            
            var result = await userManager.CreateAsync(userDTO, data.Password);

            if (result.Succeeded)
            {
                UserDTO userDto = new UserDTO
                {
                    Id = userDTO.Id,
                    Username = userDTO.UserName,
                };
                return userDto;
            }

            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? nameof(data.Password) :
                    error.Code.Contains("Email") ? nameof(data.Email) :
                    error.Code.Contains("UserName") ? nameof(data.Username) :
                    "";
                modelState.AddModelError(errorKey, error.Description);
            }
            return null;
        }   
    }
}
