namespace Core.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Bio { get; set; } = null!;
        public string ProfilePictureUrl { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;
    }
}
