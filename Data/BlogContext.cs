using Microsoft.EntityFrameworkCore;
using Core;

namespace Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<Exhibition> Exhibitions { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
