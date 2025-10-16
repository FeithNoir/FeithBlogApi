using System;

namespace Core.Models
{
    public class Artwork
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; } = null!;
    }
}
