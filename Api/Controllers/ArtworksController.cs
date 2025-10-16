using Business;
using Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtworksController : ControllerBase
    {
        private readonly ArtworkService _artworkService;

        public ArtworksController(ArtworkService artworkService)
        {
            _artworkService = artworkService;
        }

        /// <summary>
        /// Gets a list of all artworks.
        /// </summary>
        /// <returns>A list of artworks.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ArtworkDto>), 200)]
        public async Task<IEnumerable<ArtworkDto>> Get()
        {
            return await _artworkService.GetArtworks();
        }

        /// <summary>
        /// Gets a specific artwork by its ID.
        /// </summary>
        /// <param name="id">The ID of the artwork.</param>
        /// <returns>The requested artwork.</returns>
        /// <response code="200">Returns the requested artwork.</response>
        /// <response code="404">If the artwork is not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ArtworkDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ArtworkDto>> Get(int id)
        {
            var artwork = await _artworkService.GetArtwork(id);

            if (artwork == null)
            {
                return NotFound();
            }

            return artwork;
        }
    }
}
