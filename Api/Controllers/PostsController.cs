using Business;
using Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly PostService _postService;

        public PostsController(PostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetPosts()
        {
            return Ok(await _postService.GetPosts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetPost(int id)
        {
            var post = await _postService.GetPost(id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PostDto>> CreatePost(PostDto postDto)
        {
            var newPost = await _postService.CreatePost(postDto);
            return CreatedAtAction(nameof(GetPost), new { id = newPost.Id }, newPost);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdatePost(int id, PostDto postDto)
        {            
            await _postService.UpdatePost(id, postDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _postService.DeletePost(id);
            return NoContent();
        }
    }
}
