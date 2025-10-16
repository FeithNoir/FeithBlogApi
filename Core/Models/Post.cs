namespace Core.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime PublishedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        // Foreign key for Artist
        public int ArtistId { get; set; }
        public Artist Artist { get; set; } = null!;
    }
}
