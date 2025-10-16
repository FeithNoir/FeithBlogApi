using Business.Services;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Artist>> Register(Artist artist)
        {
            var createdArtist = await _authService.Register(artist);
            return CreatedAtAction(nameof(Register), new { id = createdArtist.Id }, createdArtist);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginRequest loginRequest)
        {
            var token = await _authService.Login(loginRequest.Username, loginRequest.Password);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
