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
    [Authorize]
    public class ArtworksController : ControllerBase
    {
        private readonly ArtworkService _artworkService;

        public ArtworksController(ArtworkService artworkService)
        {
            _artworkService = artworkService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<ArtworkDto>> Get()
        {
            return await _artworkService.GetArtworks();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ArtworkDto>> Get(int id)
        {
            var artwork = await _artworkService.GetArtwork(id);
            if (artwork == null) return NotFound();
            return artwork;
        }

        [HttpPost]
        public async Task<ActionResult<Artwork>> Post(Artwork artwork)
        {            
            await _artworkService.CreateArtwork(artwork);
            return CreatedAtAction(nameof(Get), new { id = artwork.Id }, artwork);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Artwork artwork)
        {
            if (id != artwork.Id)
            {
                return BadRequest();
            }
            await _artworkService.UpdateArtwork(id, artwork);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _artworkService.DeleteArtwork(id);
            return NoContent();
        }
    }
}
