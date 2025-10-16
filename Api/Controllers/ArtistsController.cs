using Business;
using Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistsController : ControllerBase
    {
        private readonly ArtistService _artistService;

        public ArtistsController(ArtistService artistService)
        {
            _artistService = artistService;
        }

        /// <summary>
        /// Gets a list of all artists.
        /// </summary>
        /// <returns>A list of artists.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ArtistDto>), 200)]
        public async Task<IEnumerable<ArtistDto>> Get()
        {
            return await _artistService.GetArtists();
        }

        /// <summary>
        /// Gets a specific artist by their ID.
        /// </summary>
        /// <param name="id">The ID of the artist.</param>
        /// <returns>The requested artist.</returns>
        /// <response code="200">Returns the requested artist.</response>
        /// <response code="404">If the artist is not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ArtistDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ArtistDto>> Get(int id)
        {
            var artist = await _artistService.GetArtist(id);

            if (artist == null)
            {
                return NotFound();
            }

            return artist;
        }
    }
}
