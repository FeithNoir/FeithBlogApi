using Business;
using Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExhibitionsController : ControllerBase
    {
        private readonly ExhibitionService _exhibitionService;

        public ExhibitionsController(ExhibitionService exhibitionService)
        {
            _exhibitionService = exhibitionService;
        }

        /// <summary>
        /// Gets a list of all exhibitions.
        /// </summary>
        /// <returns>A list of exhibitions.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ExhibitionDto>), 200)]
        public async Task<IEnumerable<ExhibitionDto>> Get()
        {
            return await _exhibitionService.GetExhibitions();
        }

        /// <summary>
        /// Gets a specific exhibition by its ID.
        /// </summary>
        /// <param name="id">The ID of the exhibition.</param>
        /// <returns>The requested exhibition.</returns>
        /// <response code="200">Returns the requested exhibition.</response>
        /// <response code="404">If the exhibition is not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ExhibitionDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ExhibitionDto>> Get(int id)
        {
            var exhibition = await _exhibitionService.GetExhibition(id);

            if (exhibition == null)
            {
                return NotFound();
            }

            return exhibition;
        }
    }
}
