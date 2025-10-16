using Business.Repositories;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace myapp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            var user = new User { Username = userForRegisterDto.Username };
            var response = await _authRepository.Register(user, userForRegisterDto.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var response = await _authRepository.Login(userForLoginDto.Username, userForLoginDto.Password);
            if (!response.Success)
            {
                return Unauthorized(response);
            }
            return Ok(response);
        }
    }
}
