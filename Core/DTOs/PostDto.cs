using System;

namespace Core.DTOs
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime PublishedAt { get; set; }
        public int ArtistId { get; set; }
        public string ArtistName { get; set; } = null!;
        public string ArtworkUrl { get; set; } = null!;
    }
}
