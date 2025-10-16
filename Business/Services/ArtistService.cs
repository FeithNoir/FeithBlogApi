
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
                .Where(a => !a.IsDeleted)
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
            var artist = await _context.Artists
                .Where(a => !a.IsDeleted && a.Id == id)
                .Select(a => new ArtistDto
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Bio = a.Bio,
                    ProfilePictureUrl = a.ProfilePictureUrl
                })
                .FirstOrDefaultAsync();

            return artist;
        }

        public async Task<Artist> CreateArtist(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
            return artist;
        }

        public async Task UpdateArtist(int id, Artist artist)
        {
            var existingArtist = await _context.Artists.FindAsync(id);
            if (existingArtist == null || existingArtist.IsDeleted)
            {
                // Consider how to handle this case. Throwing an exception is one option.
                return;
            }

            existingArtist.FirstName = artist.FirstName;
            existingArtist.LastName = artist.LastName;
            existingArtist.Bio = artist.Bio;
            existingArtist.ProfilePictureUrl = artist.ProfilePictureUrl;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteArtist(int id)
        {
            var artist = await _context.Artists.FindAsync(id);
            if (artist != null)
            {
                artist.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
