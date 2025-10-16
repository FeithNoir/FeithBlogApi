using Business;
using Core.DTOs;
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

        /// <summary>
        /// Gets a list of all posts.
        /// </summary>
        /// <returns>A list of posts.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PostDto>), 200)]
        public async Task<IEnumerable<PostDto>> Get()
        {
            return await _postService.GetPosts();
        }

        /// <summary>
        /// Gets a specific post by its ID.
        /// </summary>
        /// <param name="id">The ID of the post.</param>
        /// <returns>The requested post.</returns>
        /// <response code="200">Returns the requested post.</response>
        /// <response code="404">If the post is not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PostDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PostDto>> Get(int id)
        {
            var post = await _postService.GetPost(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }
    }
}
