
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
    public class ArtworkService
    {
        private readonly BlogContext _context;

        public ArtworkService(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ArtworkDto>> GetArtworks()
        {
            return await _context.Artworks
                .Where(a => !a.IsDeleted)
                .Select(a => new ArtworkDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    ImageUrl = a.ImageUrl,
                    CreationDate = a.CreationDate,
                    ArtistId = a.ArtistId
                })
                .ToListAsync();
        }

        public async Task<ArtworkDto?> GetArtwork(int id)
        {
            var artwork = await _context.Artworks
                .Where(a => !a.IsDeleted && a.Id == id)
                .Select(a => new ArtworkDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    ImageUrl = a.ImageUrl,
                    CreationDate = a.CreationDate,
                    ArtistId = a.ArtistId
                })
                .FirstOrDefaultAsync();

            return artwork;
        }

        public async Task<Artwork> CreateArtwork(Artwork artwork)
        {
            _context.Artworks.Add(artwork);
            await _context.SaveChangesAsync();
            return artwork;
        }

        public async Task UpdateArtwork(int id, Artwork artwork)
        {
            var existingArtwork = await _context.Artworks.FindAsync(id);
            if (existingArtwork == null || existingArtwork.IsDeleted)
            {
                return;
            }

            existingArtwork.Title = artwork.Title;
            existingArtwork.Description = artwork.Description;
            existingArtwork.ImageUrl = artwork.ImageUrl;
            existingArtwork.CreationDate = artwork.CreationDate;
            existingArtwork.ArtistId = artwork.ArtistId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteArtwork(int id)
        {
            var artwork = await _context.Artworks.FindAsync(id);
            if (artwork != null)
            {
                artwork.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
