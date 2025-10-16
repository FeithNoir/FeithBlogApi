
using Core;
using Core.DTOs;
using Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class ArtistService
    {
        private readonly BlogContext _context;

        public ArtistService(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ArtistDto>> GetArtists()
        {
            return await _context.Artists
                .Select(a => new ArtistDto
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Bio = a.Bio,
                    ProfilePictureUrl = a.ProfilePictureUrl
                })
                .ToListAsync();
        }

        public async Task<ArtistDto?> GetArtist(int id)
        {
            var artist = await _context.Artists.FindAsync(id);

            if (artist == null)
            {
                return null;
            }

            return new ArtistDto
            {
                Id = artist.Id,
                FirstName = artist.FirstName,
                LastName = artist.LastName,
                Bio = artist.Bio,
                ProfilePictureUrl = artist.ProfilePictureUrl
            };
        }
    }
}
