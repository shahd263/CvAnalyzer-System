using CvAnalyzer.Domian.Entities.IdentityModule;
using CvAnalyzer.Services_Abstraction;
using CvAnalyzer.Shared.DTOs.IdentityDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

using System.Threading.Tasks;

namespace CvAnalyzer.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationService(UserManager<ApplicationUser> userManager , IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<bool> CheckEmailAsync(string Email)
        {
            var User = await _userManager.FindByEmailAsync(Email);
            return User != null;
        }

        public async Task<UserDTO?> GetUserByEmail(string Email)
        {
            var User = await _userManager.FindByEmailAsync(Email);
            if (User is null)
                return null;
            return new UserDTO(Email, User.DisplayName, await CreateTokenAsync(User));
        }

        public async Task<UserDTO?> LoginAsync(LoginDTO loginDTO)
        {
            var User = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (User is null) 
                return null;
            var IsPasswordValid = await _userManager.CheckPasswordAsync(User, loginDTO.Password);
            if (!IsPasswordValid)
                return null;
            var Token =await CreateTokenAsync(User);
            return new UserDTO(User.Email!, User.DisplayName,Token);
        }

        public async Task<UserDTO?> RegisterAsync(RegisterDTO registerDTO)
        {
            var User = new ApplicationUser()
            {
                Email = registerDTO.Email,
                DisplayName = registerDTO.DisplayName,
                UserName = registerDTO.UserName,
                PhoneNumber = registerDTO.PhoneNumber
            };
            var Result = await _userManager.CreateAsync(User, registerDTO.Password);
            if (Result.Succeeded)
            {
                var Token = await CreateTokenAsync(User);
                return new UserDTO(User.Email, User.DisplayName, Token);
            }
            return null;
        }

        private async Task<string> CreateTokenAsync(ApplicationUser user)
        {
            //Token : [Issuer ,Audience ,Claims , Expires , SigningCredintials]
            var Claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email , user.Email!),
                new Claim(JwtRegisteredClaimNames.Name , user.UserName!)
            };
            var Roles = await _userManager.GetRolesAsync(user);
            foreach (var role in Roles)
            {
                Claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var SecretKey = _configuration["JWTOptions:SecretKey"];
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey!));
            var Cred = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var Token = new JwtSecurityToken(
                issuer: _configuration["JWTOptions:Issuer"],
                audience: _configuration["JWTOptions:Audience"],
                claims: Claims,
                expires:DateTime.UtcNow.AddHours(1),
                signingCredentials: Cred
                );
            return new JwtSecurityTokenHandler().WriteToken(Token);
        }
    }
}
