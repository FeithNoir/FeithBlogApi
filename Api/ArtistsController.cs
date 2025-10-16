
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

        [HttpGet]
        public async Task<IEnumerable<ArtistDto>> Get()
        {
            return await _artistService.GetArtists();
        }

        [HttpGet("{id}")]
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
