
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
    public class PostService
    {
        private readonly BlogContext _context;

        public PostService(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PostDto>> GetPosts()
        {
            return await _context.Posts
                .Where(p => !p.IsDeleted)
                .Select(p => new PostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    PublishedAt = p.PublishedAt,
                    ArtistId = p.ArtistId
                })
                .ToListAsync();
        }

        public async Task<PostDto?> GetPost(int id)
        {
            var post = await _context.Posts
                .Where(p => !p.IsDeleted && p.Id == id)
                .Select(p => new PostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    PublishedAt = p.PublishedAt,
                    ArtistId = p.ArtistId
                })
                .FirstOrDefaultAsync();

            return post;
        }

        public async Task<Post> CreatePost(PostDto postDto)
        {
            var post = new Post
            {
                Title = postDto.Title,
                Content = postDto.Content,
                PublishedAt = postDto.PublishedAt,
                ArtistId = postDto.ArtistId
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task UpdatePost(int id, PostDto postDto)
        {
            var existingPost = await _context.Posts.FindAsync(id);
            if (existingPost == null || existingPost.IsDeleted)
            {
                return;
            }

            existingPost.Title = postDto.Title;
            existingPost.Content = postDto.Content;
            existingPost.PublishedAt = postDto.PublishedAt;
            existingPost.ArtistId = postDto.ArtistId;

            await _context.SaveChangesAsync();
        }

        public async Task DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                post.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
