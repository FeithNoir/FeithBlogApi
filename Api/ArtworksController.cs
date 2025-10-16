
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

        [HttpGet]
        public async Task<IEnumerable<ArtworkDto>> Get()
        {
            return await _artworkService.GetArtworks();
        }

        [HttpGet("{id}")]
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
