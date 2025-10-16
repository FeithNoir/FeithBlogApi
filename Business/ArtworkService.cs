
using Core;
using Core.DTOs;
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
            var artwork = await _context.Artworks.FindAsync(id);

            if (artwork == null)
            {
                return null;
            }

            return new ArtworkDto
            {
                Id = artwork.Id,
                Title = artwork.Title,
                Description = artwork.Description,
                ImageUrl = artwork.ImageUrl,
                CreationDate = artwork.CreationDate,
                ArtistId = artwork.ArtistId
            };
        }
    }
}
