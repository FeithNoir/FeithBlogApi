
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

        [HttpGet]
        public async Task<IEnumerable<ExhibitionDto>> Get()
        {
            return await _exhibitionService.GetExhibitions();
        }

        [HttpGet("{id}")]
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
