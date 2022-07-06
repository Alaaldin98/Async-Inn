using HotelManagement.Models.DTO;
using HotelManagement.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HotelManagement.Models.Servieces
{
    public class IdentityUserService : IUserService
    {
        private UserManager<ApplicationUser> _userManager;
        private JwtTokenService _tokenService;

        public IdentityUserService(UserManager<ApplicationUser> manager, JwtTokenService jwtTokenService)
        {
            _userManager = manager;
            _tokenService = jwtTokenService;
        }

        public async Task<UserDTO> Authenticate(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                //check if password is correct
                //PasswordVerificationResult result = _userManager.PasswordHasher.VerifyHashedPassword(user.PasswordHash, password);
                if (await _userManager.CheckPasswordAsync(user, password))
                {
                    UserDTO UserDTO = new UserDTO
                    {
                        Id = user.Id,
                        Username = user.UserName,
                        Token = await _tokenService.GetToken(user, System.TimeSpan.FromMinutes(15)),
                        Roles = await _userManager.GetRolesAsync(user)
                    };
                    return UserDTO;
                }
            }
            return null;
        }

        public async Task<UserDTO> Register(RegisterUserDTO data, ModelStateDictionary modelstate)
        {
            var user = new ApplicationUser
            {
                UserName = data.Username,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber,
                PasswordHash = data.Password
            };

            var result = await _userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
                IList<string> Roles = new List<string>();
                Roles.Add("Administrator");
                await _userManager.AddToRolesAsync(user, Roles);
                UserDTO UserDTO = new UserDTO
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Token = await _tokenService.GetToken(user, System.TimeSpan.FromMinutes(15)),
                    Roles = await _userManager.GetRolesAsync(user)
                };
                return UserDTO;
            }
            foreach (var error in result.Errors)
            {
                var errorKey =
                    // nameof will go to the RegisterUser class and take property name 
                    error.Code.Contains("Password") ? /* key name will be -> */nameof(data.Password) :
                    error.Code.Contains("Email") ? /* key name will be -> */nameof(data.Email) :
                    error.Code.Contains("UserName") ? /* key name will be -> */nameof(data.Username) :
                    "";
                modelstate.AddModelError(errorKey, error.Description);
            }
            return null;
        }
        public async Task<UserDTO> GetUser(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal);
            return new UserDTO
            {
                Id = user.Id,
                Username = user.UserName
            };
        }
    }
}
