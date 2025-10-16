namespace Core.Models
{
    public class Exhibition
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Venue { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;
    }
}
