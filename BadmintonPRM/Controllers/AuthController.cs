using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Constants;
using Service.Models;
using Service.Models.User;
using Service.Services;

namespace BadmintonPRM.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<IActionResult> Authenticate([FromBody] SignInRequest request)
        {
            var response = await _authService.Authenticate(request);
            return Ok(BaseResponse.OkResponseDto(response));
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<IActionResult> Register([FromBody] SignUpRequest request)
        {
            var response = await _authService.Register(request);
            return Ok(BaseResponse.OkResponseDto(response));
        }
    }
}
