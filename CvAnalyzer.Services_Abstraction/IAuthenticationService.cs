using CvAnalyzer.Shared.DTOs.IdentityDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAnalyzer.Services_Abstraction
{
    public interface IAuthenticationService
    {
        Task<UserDTO?> LoginAsync(LoginDTO loginDTO);
        Task<UserDTO?> RegisterAsync(RegisterDTO registerDTO);
        Task<bool> CheckEmailAsync(string Email);
        Task<UserDTO?> GetUserByEmail(string Email);
    }
}
