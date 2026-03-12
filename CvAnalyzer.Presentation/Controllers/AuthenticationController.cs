using CvAnalyzer.Services_Abstraction;
using CvAnalyzer.Shared.DTOs.IdentityDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CvAnalyzer.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var result = await _authenticationService.LoginAsync(loginDTO);
            return Ok(result);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            var Result = await _authenticationService.RegisterAsync(registerDTO);
            return Ok(Result);
        }

        [HttpGet("EmailExists")]
        public async Task<ActionResult<bool>> CheckEmail(string Email)
        {
            var Result = await _authenticationService.CheckEmailAsync(Email);
            return Ok(Result);
        }


        [Authorize]
        [HttpGet("CurrentUser")]
        public async Task<ActionResult<UserDTO>> CurrentUser()
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var Result = await _authenticationService.GetUserByEmail(Email!);
            return Ok(Result);
        }
    }
}
