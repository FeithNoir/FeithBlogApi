
using Core;
using Core.DTOs;
using Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class ExhibitionService
    {
        private readonly BlogContext _context;

        public ExhibitionService(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExhibitionDto>> GetExhibitions()
        {
            return await _context.Exhibitions
                .Select(e => new ExhibitionDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Description = e.Description,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    Venue = e.Venue
                })
                .ToListAsync();
        }

        public async Task<ExhibitionDto?> GetExhibition(int id)
        {
            var exhibition = await _context.Exhibitions.FindAsync(id);

            if (exhibition == null)
            {
                return null;
            }

            return new ExhibitionDto
            {
                Id = exhibition.Id,
                Title = exhibition.Title,
                Description = exhibition.Description,
                StartDate = exhibition.StartDate,
                EndDate = exhibition.EndDate,
                Venue = exhibition.Venue
            };
        }
    }
}
