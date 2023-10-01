using LoveLiveCZ.Files;
using LoveLiveCZ.Manager;
using LoveLiveCZ.Models.DataTransferObjects;
using LoveLiveCZ.Utilities.Enums;
using LoveLiveCZ.Utilities.Extensions;
using LoveLiveCZ.Utilities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoveLiveCZ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostController : ControllerBase
    {
        private readonly PostManager _postManager;
        private readonly ImageFileVerifier _imageFileVerifier;

        public PostController(PostManager postManager, ImageFileVerifier imageFileVerifier)
        {
            _postManager = postManager;
            _imageFileVerifier = imageFileVerifier;
        }

        /// <summary>
        /// Asynchronously gets a post by id
        /// </summary>
        /// <param name="id">ID of a post to return</param>
        /// <returns><see cref="PostDto"/> of a post with selected id or 400 error</returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PostDto>> GetPost([FromRoute] Guid id)
        {
            var userId = User.GetUserId();
            var result = await _postManager.GetPost(userId, id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Asynchronously lists posts
        /// </summary>
        /// <param name="listOptions">Options to include when listing</param>
        /// <returns>List of data transfer objects <see cref="PostDto"/></returns>
        [HttpGet("list")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<PostDto>>> ListPosts([FromQuery] ListOptions listOptions = null)
        {
            var userId = User.TryGetUserId();
            var result = await _postManager.ListPostsAsync(userId, listOptions);
            return Ok(result.ToList());
        }

        /// <summary>
        /// Asynchronously creates a new post for current user
        /// </summary>
        /// <param name="postDto">Post to create</param>
        /// <returns>Created post as <see cref="PostDto"/></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PostDto>> PostAsync([FromForm] NewPostDto postDto)
        {
            var userId = User.GetUserId();

            if (postDto?.File?.Any((file) => !_imageFileVerifier.Verify(file)) ?? false)
            {
                return BadRequest("Invalid file type");
            }

            var result = await _postManager.PostNewPost(userId, postDto);
            return Ok(result);
        }
        
        /// <summary>
        /// Asynchronously deletes a post by its ID
        /// </summary>
        /// <param name="postId">ID of a post to delete</param>
        /// <returns>Empty body</returns>
        [HttpDelete("{postId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PostDto>> DeleteAsync([FromRoute] Guid postId)
        {
            var exists = await _postManager.ExistsAsync(postId);

            if (!exists)
            {
                return NotFound();
            }
            
            var userId = User.GetUserId();
            bool canDelete = User.IsRole(UserRoleType.Moderator);

            if (!canDelete)
            {
                canDelete = await _postManager.CheckOwnership(userId, postId);
            }

            if (!canDelete)
            {
                return Forbid();
            }

            var result = await _postManager.DeleteAsync(postId);

            if (result == Guid.Empty)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            
            return Ok(result);
        }
    }
}