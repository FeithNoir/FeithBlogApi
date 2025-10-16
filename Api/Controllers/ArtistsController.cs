using Business;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize] // Protect all endpoints in this controller
    public class ArtistsController : ControllerBase
    {
        private readonly ArtistService _artistService;

        public ArtistsController(ArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        [AllowAnonymous] // You might want to allow anonymous access to the list
        public async Task<IEnumerable<ArtistDto>> Get()
        {
            return await _artistService.GetArtists();
        }

        [HttpGet("{id}")]
        [AllowAnonymous] // And to individual artists
        public async Task<ActionResult<ArtistDto>> Get(int id)
        {
            var artist = await _artistService.GetArtist(id);
            if (artist == null) return NotFound();
            return artist;
        }

        [HttpPost]
        public async Task<ActionResult<Artist>> Post(Artist artist)
        {
            await _artistService.CreateArtist(artist);
            return CreatedAtAction(nameof(Get), new { id = artist.Id }, artist);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Artist artist)
        {
            if (id != artist.Id)
            {
                return BadRequest();
            }
            await _artistService.UpdateArtist(id, artist);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _artistService.DeleteArtist(id);
            return NoContent();
        }
    }
}
