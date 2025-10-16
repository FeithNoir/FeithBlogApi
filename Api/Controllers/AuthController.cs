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

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="userForRegisterDto">The user registration information.</param>
        /// <returns>A response indicating success or failure.</returns>
        /// <response code="200">If the user is registered successfully.</response>
        /// <response code="400">If the registration fails.</response>
        [HttpPost("register")]
        [ProducesResponseType(typeof(ServiceResponse<int>), 200)]
        [ProducesResponseType(typeof(ServiceResponse<int>), 400)]
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

        /// <summary>
        /// Logs in a user.
        /// </summary>
        /// <param name="userForLoginDto">The user login information.</param>
        /// <returns>A JWT token if login is successful.</returns>
        /// <response code="200">Returns a JWT token.</response>
        /// <response code="401">If the login is unsuccessful.</response>
        [HttpPost("login")]
        [ProducesResponseType(typeof(ServiceResponse<string>), 200)]
        [ProducesResponseType(typeof(ServiceResponse<string>), 401)]
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
