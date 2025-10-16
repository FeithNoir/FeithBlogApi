
namespace Core.DTOs
{
    public class ArtistDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Bio { get; set; } = null!;
        public string ProfilePictureUrl { get; set; } = null!;
    }
}
