using System;

namespace Core.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime PublishedDate { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; } = null!;
    }
}
