
using System;

namespace Core.DTOs
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime PublishedDate { get; set; }
        public int ArtistId { get; set; }
    }
}
