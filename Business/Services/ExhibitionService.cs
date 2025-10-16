
using Core;
using Core.DTOs;
using Core.Models;
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
                .Where(e => !e.IsDeleted)
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
            var exhibition = await _context.Exhibitions
                .Where(e => !e.IsDeleted && e.Id == id)
                .Select(e => new ExhibitionDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Description = e.Description,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    Venue = e.Venue
                })
                .FirstOrDefaultAsync();

            return exhibition;
        }

        public async Task<Exhibition> CreateExhibition(Exhibition exhibition)
        {
            _context.Exhibitions.Add(exhibition);
            await _context.SaveChangesAsync();
            return exhibition;
        }

        public async Task UpdateExhibition(int id, Exhibition exhibition)
        {
            var existingExhibition = await _context.Exhibitions.FindAsync(id);
            if (existingExhibition == null || existingExhibition.IsDeleted)
            {
                return;
            }

            existingExhibition.Title = exhibition.Title;
            existingExhibition.Description = exhibition.Description;
            existingExhibition.StartDate = exhibition.StartDate;
            existingExhibition.EndDate = exhibition.EndDate;
            existingExhibition.Venue = exhibition.Venue;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteExhibition(int id)
        {
            var exhibition = await _context.Exhibitions.FindAsync(id);
            if (exhibition != null)
            {
                exhibition.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
