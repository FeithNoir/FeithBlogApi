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
    public class ExhibitionsController : ControllerBase
    {
        private readonly ExhibitionService _exhibitionService;

        public ExhibitionsController(ExhibitionService exhibitionService)
        {
            _exhibitionService = exhibitionService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<ExhibitionDto>> Get()
        {
            return await _exhibitionService.GetExhibitions();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ExhibitionDto>> Get(int id)
        {
            var exhibition = await _exhibitionService.GetExhibition(id);
            if (exhibition == null) return NotFound();
            return exhibition;
        }

        [HttpPost]
        public async Task<ActionResult<Exhibition>> Post(Exhibition exhibition)
        {
            await _exhibitionService.CreateExhibition(exhibition);
            return CreatedAtAction(nameof(Get), new { id = exhibition.Id }, exhibition);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Exhibition exhibition)
        {
            if (id != exhibition.Id)
            {
                return BadRequest();
            }
            await _exhibitionService.UpdateExhibition(id, exhibition);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _exhibitionService.DeleteExhibition(id);
            return NoContent();
        }
    }
}
